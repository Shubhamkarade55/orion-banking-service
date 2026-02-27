using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orion.Banking.Application.Interfaces;

namespace Orion.Banking.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string accountNumber, string holderName)
        {
            var account = await _accountService.CreateAccountAsync(accountNumber, holderName);
            return Ok(account);
        }

        [HttpPost("{accountNumber}/credit")]
        public async Task<IActionResult> Credit(string accountNumber, decimal amount)
        {
            await _accountService.CreditAsync(accountNumber, amount);
            return Ok("Amount credited successfully");
        }

        [HttpPost("{accountNumber}/debit")]
        public async Task<IActionResult> Debit(string accountNumber, decimal amount)
        {
            await _accountService.DebitAsync(accountNumber, amount);
            return Ok("Amount debited successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }
    }
}
