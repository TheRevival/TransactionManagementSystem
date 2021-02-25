using System;
using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Data.Models;

namespace TransactionManagementSystem.Data
{
    public class TransactionManagementSystemDbContext : DbContext
    {
        public TransactionManagementSystemDbContext(DbContextOptions options)
            : base(options)
        { }
        
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
    }
}