using System.Collections.Generic;

namespace TransactionManagementSystem.Data.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}