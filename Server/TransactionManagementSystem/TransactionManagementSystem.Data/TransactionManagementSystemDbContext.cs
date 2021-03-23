using System;
using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Data.Models;
using TransactionManagementSystem.Data.Models.Enums;

namespace TransactionManagementSystem.Data
{
    public class TransactionManagementSystemDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public TransactionManagementSystemDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // map enum types to string to store it in database
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Type)
                .HasConversion<string>();
                
            base.OnModelCreating(modelBuilder);
        }
    }
}