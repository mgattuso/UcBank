using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UcBank.Data;

namespace UcBank.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UcBankContext _context;

        public IndexModel(ILogger<IndexModel> logger, UcBank.Data.UcBankContext context)
        {
            _logger = logger;
            _context = context;
        }

        public int TotalAccountHolders { get; set; }
        public int TotalAccounts { get; set; }
        public decimal AverageAccountBalance { get; set; }
        public decimal TotalDeposits { get; set; }
        public int TransactionsToday { get; set; }

        public async Task OnGetAsync()
        {
            TotalAccountHolders = await _context.AccountHolder.CountAsync();
            TotalAccounts = await _context.BankAccount.CountAsync();
            AverageAccountBalance = await _context.BankAccount.AverageAsync(x => x.CurrentBalance);
            TotalDeposits = await _context.BankAccount.SumAsync(x => x.CurrentBalance);
            TransactionsToday = await _context.Transaction.CountAsync(x => x.TransactionDate >= DateTime.Today);

        }
    }
}
