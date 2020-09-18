using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UcBank.Models
{
    public class AccountHolder
    {
        public int AccountHolderId { get; set; }
       
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        [DisplayName("Social Security Number")]
        public string SocialSecurityNumber { get; set; } // ADDED
        
        [DisplayName("Platinum Member")]
        public bool PlatinumMember { get; set; }         // ADDED 
        // AN ACCOUNT HOLDER HAS MANY BANK ACCOUNTS
        public List<BankAccount> BankAccounts { get; set; }

        public string Notes { get; set; }
    }
}