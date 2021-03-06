﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly UcBank.Data.UcBankContext _context;

        public DetailsModel(UcBank.Data.UcBankContext context)
        {
            _context = context;
        }

        public AccountHolder AccountHolder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AccountHolder = await _context.AccountHolder.Include(x => x.BankAccounts).FirstOrDefaultAsync(m => m.AccountHolderId == id);

            if (AccountHolder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
