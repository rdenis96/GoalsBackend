using DataLayer.Definitions;
using Domain.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Context
{
    public class MSSqlContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        //public DbSet<AccountProfile> AccountsProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=WORKSTATION9\\SQLEXPRESS;Initial Catalog=TripPlanner;Integrated Security=True;TrustServerCertificate=True");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-G4QH1FI\\SQLEXPRESS;Initial Catalog=Goals;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AccountDefinitions.Set(modelBuilder);
        }
    }
}
