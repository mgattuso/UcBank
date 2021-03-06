﻿using System;
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
    public class EditModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public EditModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AccountHolder = await _context.AccountHolder.FirstOrDefaultAsync(m => m.AccountHolderId == id);

            if (AccountHolder == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public AccountHolder AccountHolder { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // CHECK BUILT-IN VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
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
            var currentId = AccountHolder.AccountHolderId;
            bool ssnAlreadyExists = await _context.AccountHolder.AnyAsync(x => x.SocialSecurityNumber == ssn && x.AccountHolderId != currentId);

            if (ssnAlreadyExists)
            {
                ModelState.AddModelError("AccountHolder.SocialSecurityNumber", "Account holder with this SSN already exists");
            }

            // CHECK AGAIN AFTER CUSTOM VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AccountHolder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountHolderExists(AccountHolder.AccountHolderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AccountHolderExists(int id)
        {
            return _context.AccountHolder.Any(e => e.AccountHolderId == id);
        }
    }
}
