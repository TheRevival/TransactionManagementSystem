using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransactionManagementSystem.Data.Models
{
    public class Client
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public string FullName { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}