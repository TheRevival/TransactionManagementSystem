using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Data;
using TransactionManagementSystem.Data.Models;
using TransactionManagementSystem.Service.Exceptions;
using TransactionManagementSystem.Service.Interfaces;

namespace TransactionManagementSystem.Service.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionManagementSystemDbContext _db;

        public TransactionService(TransactionManagementSystemDbContext db)
        {
            _db = db;
        }

        public async Task Create(Transaction transaction)
        {
            var exists = await Exists(transaction);
            if (!exists)
            {
                await _db.Transactions.AddAsync(transaction);
                await _db.SaveChangesAsync();
                return;
            }
            
            await UpdateTransactionById(transaction.Id, transaction.Status);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _db.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionById(long transactionId)
        {
            var transaction = await _db.Transactions.FindAsync(transactionId);
            
            return transaction ?? throw new TransactionDoesNotExistException();
        }

        public async Task<bool> Exists(long transactionId)
        {
            return await _db.Transactions.FindAsync(transactionId) is not null;
        }

        public async Task<bool> Exists(Transaction transaction)
        {
            return await Exists(transaction.Id);
        }

        public async Task UpdateTransactionById(long transactionId, TransactionStatus newTransactionStatus)
        {
            var transaction = await GetTransactionById(transactionId);
            transaction.Status = newTransactionStatus;
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteTransactionById(long transactionId)
        {
            var exists = await Exists(transactionId);
            if (!exists)
            {
                //throw new TransactionDoesNotExistException();
                // if transaction already doesn't exist, we probably don't need to throw an exception.
                return;
            }

            var transaction = await GetTransactionById(transactionId);
            _db.Transactions.Remove(transaction);
            await _db.SaveChangesAsync();
        }
    }
}