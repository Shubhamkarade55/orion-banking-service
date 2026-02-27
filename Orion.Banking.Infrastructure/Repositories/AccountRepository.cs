using Orion.Banking.Application.Interfaces;
using Orion.Banking.Domain.Entities;
using Orion.Banking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Banking.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository   
    {
        private readonly BankingDbContext _context;

        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

    }
}
