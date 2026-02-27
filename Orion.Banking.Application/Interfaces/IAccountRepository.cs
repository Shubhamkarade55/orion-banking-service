using Orion.Banking.Domain.Entities;
using System.Security.Principal;

namespace Orion.Banking.Application.Interfaces;

public interface IAccountRepository
{
    Task AddAsync(Account account);
    Task<Account?> GetByAccountNumberAsync(string accountNumber);
    Task<IEnumerable<Account>> GetAllAsync();
}