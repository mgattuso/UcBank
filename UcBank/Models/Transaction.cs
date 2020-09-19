using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UcBank.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        
        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public BankAccount Account { get; set; }

        [DisplayName("Account")]
        public int AccountId { get; set; }
    }
}
