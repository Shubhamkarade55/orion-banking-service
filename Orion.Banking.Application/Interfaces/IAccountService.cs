using Orion.Banking.Domain.Entities;
using System.Security.Principal;

namespace Orion.Banking.Application.Interfaces;

public interface IAccountService
{
    Task<Account> CreateAccountAsync(string accountNumber, string holderName);
    Task CreditAsync(string accountNumber, decimal amount);
    Task DebitAsync(string accountNumber, decimal amount);
    Task<IEnumerable<Account>> GetAllAccountsAsync();
}