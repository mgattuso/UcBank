using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UcBank.Models
{
    public class AccountHolder
    {
        public int AccountHolderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SocialSecurityNumber { get; set; }
        public bool PlatinumMember { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
        public string Notes { get; set; }
    }
}