using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionManagementSystem.Data.Models;

namespace TransactionManagementSystem.Service.Interfaces
{
    public interface ITransactionService
    {
        Task Create(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionById(long transactionId);
        Task<bool> Exists(long transactionId);
        Task<bool> Exists(Transaction transaction);
        Task UpdateTransactionById(long transactionId, TransactionStatus newTransactionStatus);
        Task DeleteTransactionById(long transactionId);
    }
}