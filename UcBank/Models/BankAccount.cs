using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UcBank.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime Created { get; set;  }
        public string Name { get; set; }
        public DateTime? LastDeposit { get; set; } 
        public decimal InterestRate { get; set; }
        public AccountHolder AccountHolder { get; set; }
        public int AccountHolderId { get; set; }
        public List<Transaction> Transactions { get; set; }
    }


}
