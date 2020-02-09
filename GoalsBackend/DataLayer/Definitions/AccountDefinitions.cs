using Domain.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Definitions
{
    static internal class AccountDefinitions
    {
        public static void Set(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(k => k.Id);
            modelBuilder.Entity<Account>().Property(p => p.Username);
            modelBuilder.Entity<Account>().Property(p => p.Email);
            modelBuilder.Entity<Account>().Property(p => p.PasswordHash);
            modelBuilder.Entity<Account>().Property(p => p.Ip);
            modelBuilder.Entity<Account>().Property(p => p.CreatedDate).HasDefaultValue(DateTime.UtcNow).HasColumnType("datetime2");
            modelBuilder.Entity<Account>().Property(p => p.LastLoginDate).HasColumnType("datetime2");
        }
    }
}
