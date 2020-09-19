using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UcBank.Data;
using UcBank.Models;

namespace UcBank.Pages.AccountHolders
{
    public class DeleteModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public DeleteModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountHolder AccountHolder { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AccountHolder = await _context.AccountHolder.FindAsync(id);

            if (AccountHolder != null)
            {
                _context.AccountHolder.Remove(AccountHolder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
