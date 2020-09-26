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
    public class SearchModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public SearchModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        public IList<AccountHolder> AccountHolder { get; set; }
        public bool SearchCompleted { get; set; }
        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                SearchCompleted = true;
                AccountHolder = await _context.AccountHolder
                        .Where(x => x.LastName.StartsWith(query))
                        .ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                AccountHolder = new List<AccountHolder>();
            }
        }
    }
}
