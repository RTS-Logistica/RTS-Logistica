using Domain.Entities;
using Infraestructure.Persistence.Configuration;
using Infraestructure.Persistence.Inserts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<BatchCard> BatchCard { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<BankFormat> BankFormat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BankCardDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserAddressConfiguration());
            modelBuilder.ApplyConfiguration(new UserDataConfiguration());
            modelBuilder.ApplyConfiguration(new BatchCardConfiguration());
            modelBuilder.ApplyConfiguration(new BankFormatConfiguration());

            modelBuilder.ApplyConfiguration(new BankFormatInsert());
            modelBuilder.ApplyConfiguration(new BatchCardInsert());
            modelBuilder.ApplyConfiguration(new UserDataInsert());
            modelBuilder.ApplyConfiguration(new UserAddressInsert());
        }
    }
}
