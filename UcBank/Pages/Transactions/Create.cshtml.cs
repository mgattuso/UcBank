using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UcBank.Data;
using UcBank.Models;

namespace UcBank.Pages.Transactions
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
        ViewData["AccountId"] = new SelectList(_context.BankAccount, "BankAccountId", "AccountInformation");
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transaction.Add(Transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
