using Orion.Banking.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Orion.Banking.Application.Interfaces;
using Orion.Banking.Domain.Entities;

namespace Orion.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> CreateAccountAsync(string accountNumber, string holderName)
        {
            var account = new Account(accountNumber, holderName);
            await _accountRepository.AddAsync(account);
            return account;
        }

        public async Task CreditAsync(string accountNumber, decimal amount)
        {
            var account = await _accountRepository.GetByAccountNumberAsync(accountNumber)
                          ?? throw new Exception("Account not found");

            account.Credit(amount);
        }

        public async Task DebitAsync(string accountNumber, decimal amount)
        {
            var account = await _accountRepository.GetByAccountNumberAsync(accountNumber)
                          ?? throw new Exception("Account not found");

            account.Debit(amount);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAsync();
        }
    }
}
