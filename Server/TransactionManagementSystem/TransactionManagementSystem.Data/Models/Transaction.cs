using System;
using TransactionManagementSystem.Data.Models.Enums;

namespace TransactionManagementSystem.Data.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public decimal Amount { get; set; }
    }
}