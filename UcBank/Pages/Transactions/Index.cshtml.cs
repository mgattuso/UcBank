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
    public class IndexModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public IndexModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transaction { get;set; }

        public async Task OnGetAsync()
        {
            Transaction = await _context.Transaction
                .Include(t => t.Account).ToListAsync();
        }
    }
}
