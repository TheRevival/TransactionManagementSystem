using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;
using Swashbuckle.AspNetCore.Annotations;
using TransactionManagementSystem.Data.Models;
using TransactionManagementSystem.Service.Interfaces;
using Transaction = TransactionManagementSystem.Data.Models.Transaction;

namespace TransactionManagementSystem.Web.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ICsvService _csvService;
        public TransactionController(ITransactionService transactionService, ICsvService csvService)
        {
            _transactionService = transactionService;
            _csvService = csvService;
        }
        
        /// <summary>
        /// Returns all transactions from database.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Returns all transactions from database.")]
        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactions();
            
            return transactions;
        }
        
        /// <summary>
        /// Returns transaction by Id.
        /// </summary>
        [HttpGet("{id}", Name = "GetTransactionById")]
        [SwaggerOperation(Summary = "Returns transaction by Id.")]
        public async Task<IActionResult> GetTransactionById(long transactionId)
        {
            try
            {
                var transaction = await _transactionService.GetTransactionById(transactionId);
                return Ok(transaction);
            }
            catch (TransactionInDoubtException ex)
            {
                // TODO: add logging.
                return NotFound();
            }
        }

        /// <summary>
        /// Merges uploaded .csv-file with database.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Merges uploaded .csv-file with database.")]
        public async Task<IActionResult> MergeCsvFileWithDatabase(IFormFile file)
        {
            var transactionsFromFile = await _csvService.GetAllTransactionsFromFile(file);
            await _csvService.Merge(transactionsFromFile);

            return Ok(transactionsFromFile);
        }
    }
}