using Microsoft.EntityFrameworkCore;
using Orion.Banking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Banking.Infrastructure.Data
{
    public class BankingDbContext : DbContext
    { 
        public BankingDbContext(DbContextOptions<BankingDbContext> options)
        : base(options)
        {
        }

        public DbSet<Account> Accounts => Set<Account>();
    }
}
