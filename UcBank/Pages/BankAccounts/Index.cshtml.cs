﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public IndexModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        public IList<BankAccount> BankAccount { get;set; }

        public async Task OnGetAsync()
        {
            BankAccount = await _context.BankAccount
                .Include(b => b.AccountHolder).ToListAsync();
        }
    }
}
