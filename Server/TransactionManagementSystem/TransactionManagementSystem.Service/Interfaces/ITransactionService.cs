using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionManagementSystem.Data.Models;
using TransactionManagementSystem.Data.Models.Enums;

namespace TransactionManagementSystem.Service.Interfaces
{
    public interface ITransactionService
    {
        /// <summary>
        /// Creates new transaction if it didn't exists before.
        /// Otherwise, calls UpdateTransactionById with the id of given transaction and updates its status.
        /// </summary>
        Task Create(Transaction transaction);
        /// <summary>
        /// Returns all transactions from database.
        /// </summary>
        Task<IEnumerable<Transaction>> GetAllTransactions();
        /// <summary>
        /// Returns transaction with given id from database if it exists.
        /// Otherwise, throws TransactionDoesNotExistException. 
        /// </summary>
        Task<Transaction> GetTransactionById(long transactionId);
        /// <summary>
        /// Returns true if transaction with given id exists.
        /// Otherwise, returns false.
        /// </summary>
        Task<bool> Exists(long transactionId);
        /// <summary>
        /// Returns true if given transaction has the same id with other transaction,
        /// that already stores in database.
        /// Otherwise, returns false.
        /// </summary>
        Task<bool> Exists(Transaction transaction);
        /// <summary>
        /// Updates transaction's status with given id on given status if it exists.
        /// Otherwise, throws TransactionDoesNotExistException.
        /// </summary>
        Task UpdateTransactionById(long transactionId, TransactionStatus newTransactionStatus);
        /// <summary>
        /// Deletes transaction with given id if it exists.
        /// </summary>
        Task DeleteTransactionById(long transactionId);
    }
}