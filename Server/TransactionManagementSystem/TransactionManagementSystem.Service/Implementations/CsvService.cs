using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TransactionManagementSystem.Data.Models;
using TransactionManagementSystem.Data.Models.Enums;
using TransactionManagementSystem.Service.Exceptions;
using TransactionManagementSystem.Service.Extentions;
using TransactionManagementSystem.Service.Interfaces;

namespace TransactionManagementSystem.Service.Implementations
{
    public class CsvService : ICsvService
    {
        private readonly ITransactionService _transactionService;
        private readonly IClientService _clientService;

        public CsvService(ITransactionService transactionService, IClientService clientService)
        {
            _transactionService = transactionService;
            _clientService = clientService;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsFromFile(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            
            if (extension is not ".csv")
            {
                throw new InvalidFileExtensionException();
            }

            var allDataFromFile = await file.ReadAsStringAsync();
            

            var transactions = allDataFromFile
                .Split(Environment.NewLine)
                .Skip(1)
                .Select(s => 
                   s.Replace("\\r", "")
                    .Replace("\\n", "")
                    .Replace(" ", ""))
                .Select(async lineFromCsv=> await ToTransaction(lineFromCsv))
                .Select(task => task.Result);
            
            return transactions;
        }
        public async Task<Transaction> ToTransaction(string lineFromCsv)
        {
            // lineFromCsv is 1,pending,Refill,Dale Cotton,$300
            // bruteforce here, but we can't use something like https://github.com/TinyCsvParser/TinyCsvParser because automapper is banned as tech task.
            var properties = lineFromCsv.Split(",");
            return new Transaction
            {
                Id = int.Parse(properties[0]),
                Status = (TransactionStatus) Enum.Parse(typeof(TransactionStatus), properties[1], false),
                Type = (TransactionType) Enum.Parse(typeof(TransactionType), properties[2], false),
                Client = await _clientService.Exists(properties[3]) 
                    ? await _clientService.GetByFullName(properties[3])
                    : await _clientService.Create(properties[3]) 
                
                // TODO: another migration -- change the status and type to enum
                // also add try parse to status and try parse to type.
                //Status = properties[0]
                
            };
        }

        public async Task Merge(IEnumerable<Transaction> transactionsToMerge)
        {
            foreach (var transaction in transactionsToMerge)
            {
                await _transactionService.Create(transaction);
            }
        }
    }
}