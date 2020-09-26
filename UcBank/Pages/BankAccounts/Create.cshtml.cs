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

namespace UcBank.Pages.BankAccounts
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
            ViewData["AccountHolderId"] = new SelectList(_context.AccountHolder, "AccountHolderId", "FullName");
            return Page();
        }

        [BindProperty]
        public BankAccount BankAccount { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // REPOPULATE DROPDOWN IF VALIDATION ERROR OCCURS
            ViewData["AccountHolderId"] = new SelectList(_context.AccountHolder, "AccountHolderId", "FullName");

            // RETURN IF BUILT-IN VALIDATION FAILS
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BankAccount.Add(BankAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
