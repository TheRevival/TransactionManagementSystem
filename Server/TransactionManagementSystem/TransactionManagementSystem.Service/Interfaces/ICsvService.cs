using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TransactionManagementSystem.Data.Models;

namespace TransactionManagementSystem.Service.Interfaces
{
    public interface ICsvService
    {
        /// <summary>
        /// Returns all mapped transaction from .csv file.
        /// If input file type is not a .csv, throws InvalidFileExtensionException.
        /// </summary>
        Task<IEnumerable<Transaction>> GetAllTransactionsFromFile(IFormFile file);
        /// <summary>
        /// Maps raw data into Transaction.
        /// </summary>
        Task<Transaction> ToTransaction(string lineFromCsv);
        /// <summary>
        /// Merges mapped transactions with transactions stores in database. 
        /// </summary>
        Task Merge(IEnumerable<Transaction> transactionsToMerge);
    }
}