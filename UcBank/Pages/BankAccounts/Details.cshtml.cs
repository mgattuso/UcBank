using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UcBank.Data;
using UcBank.Models;

namespace UcBank.Pages.BankAccounts
{
    public class DetailsModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public DetailsModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        public BankAccount BankAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BankAccount = await _context.BankAccount
                .Include(b => b.AccountHolder).FirstOrDefaultAsync(m => m.BankAccountId == id);

            if (BankAccount == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
