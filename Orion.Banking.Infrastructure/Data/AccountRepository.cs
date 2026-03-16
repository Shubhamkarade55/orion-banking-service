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
            await _accountRepository.UpdateAsync(account);
        }

        public async Task DebitAsync(string accountNumber, decimal amount)
        {
            var account = await _accountRepository.GetByAccountNumberAsync(accountNumber)
                          ?? throw new Exception("Account not found");

            account.Debit(amount);
            await _accountRepository.UpdateAsync(account);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAsync();
        }
    }
}
