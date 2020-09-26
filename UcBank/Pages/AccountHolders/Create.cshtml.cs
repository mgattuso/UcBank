using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UcBank.Data;
using UcBank.Models;

namespace UcBank.Pages.AccountHolders
{
    public class CreateModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public CreateModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AccountHolder AccountHolder { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // DATE OF BIRTH VALIDATION
            var birthYear = AccountHolder.DateOfBirth.Year;
            var latestAllowedYear = DateTime.Now.Year - 18;
            if (birthYear > latestAllowedYear)
            {
                ModelState.AddModelError("AccountHolder.DateOfBirth", "Account holder must be 18 years or older");
            }

            // SSN VALIDATION
            var ssn = AccountHolder.SocialSecurityNumber;
            bool ssnAlreadyExists = await _context.AccountHolder.AnyAsync(x => x.SocialSecurityNumber == ssn);

            if (ssnAlreadyExists)
            {
                ModelState.AddModelError("AccountHolder.SocialSecurityNumber", "Account holder with this SSN already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AccountHolder.Add(AccountHolder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
