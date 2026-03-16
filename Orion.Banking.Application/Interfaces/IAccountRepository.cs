using System.Collections.Generic;
using System.Threading.Tasks;
using Orion.Banking.Domain.Entities;

namespace Orion.Banking.Application.Interfaces;

public interface IAccountRepository
{
    Task AddAsync(Account account);
    Task<Account?> GetByAccountNumberAsync(string accountNumber);
    Task<IEnumerable<Account>> GetAllAsync();

    // Persist changes for an existing account
    Task UpdateAsync(Account account);
}