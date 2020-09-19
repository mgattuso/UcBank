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

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }
        
        [DisplayName("Current Balance")]
        [DataType(DataType.Currency)]
        public decimal CurrentBalance { get; set; }
        public DateTime Created { get; set;  }
        public string Name { get; set; }
        
        [DisplayName("Last Deposit")]
        public DateTime? LastDeposit { get; set; } 
        
        [DisplayName("Interest Rate")]
        public decimal InterestRate { get; set; }

        [DisplayName("Account Holder")]
        public AccountHolder AccountHolder { get; set; }
        
        [DisplayName("Account Holder")]
        public int AccountHolderId { get; set; }

        public List<Transaction> Transactions { get; set; }
    }


}
