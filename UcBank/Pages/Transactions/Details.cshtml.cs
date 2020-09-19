using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UcBank.Data;
using UcBank.Models;

namespace UcBank.Pages.Transactions
{
    public class DetailsModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public DetailsModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction = await _context.Transaction
                .Include(t => t.Account).FirstOrDefaultAsync(m => m.TransactionId == id);

            if (Transaction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
