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
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Social Security Number")]
        [Required]
        [StringLength(11)]
        [RegularExpression("^\\d{3}-?\\d{2}-?\\d{4}$")]
        public string SocialSecurityNumber { get; set; }

        [DisplayName("Platinum Member")]
        public bool PlatinumMember { get; set; }
        
        [DisplayName("Bank Accounts")]
        public List<BankAccount> BankAccounts { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }
    }
}