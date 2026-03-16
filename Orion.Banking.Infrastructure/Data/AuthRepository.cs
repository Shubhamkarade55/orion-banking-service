using Microsoft.EntityFrameworkCore;
using Orion.Banking.Application.Interfaces;
using Orion.Banking.Domain.Entities;
using Orion.Banking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Banking.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BankingDbContext _context;

        public AuthRepository(BankingDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
