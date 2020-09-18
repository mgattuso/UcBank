using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UcBank.Models;

namespace UcBank.Data
{
    public class UcBankContext : DbContext
    {
        public UcBankContext (DbContextOptions<UcBankContext> options)
            : base(options)
        {
        }

        public DbSet<UcBank.Models.AccountHolder> AccountHolder { get; set; }

        public DbSet<UcBank.Models.BankAccount> BankAccount { get; set; }

        public DbSet<UcBank.Models.Transaction> Transaction { get; set; }
    }
}
