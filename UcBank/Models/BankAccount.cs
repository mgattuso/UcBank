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
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string AccountNumber { get; set; }
        
        [DisplayName("Current Balance")]
        [Range(-200, 1000000)]
        [DataType(DataType.Currency)]
        public decimal CurrentBalance { get; set; }
        public DateTime Created { get; set;  }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        [DisplayName("Last Deposit")]
        public DateTime? LastDeposit { get; set; } 
        
        [DisplayName("Interest Rate")]
        [Range(0,100)]
        public decimal InterestRate { get; set; }

        [DisplayName("Account Holder")]
        public AccountHolder AccountHolder { get; set; }
        
        [DisplayName("Account Holder")]
        public int AccountHolderId { get; set; }

        public List<Transaction> Transactions { get; set; }

        public string AccountInformation
        {
            get { return $"{AccountNumber} ({Name})"; }
        }
    }


}
