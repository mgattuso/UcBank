using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UcBank.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        
        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Range(-100,100)]
        public decimal Amount { get; set; }
        public BankAccount Account { get; set; }

        [DisplayName("Account")]
        public int AccountId { get; set; }
    }
}
