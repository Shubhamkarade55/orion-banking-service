using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Banking.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; private set; }
        public string AccountNumber { get; private set; }
        public string HolderName { get; private set; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, string holderName)
        {
            Id = Guid.NewGuid();
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = 0;
        }

        public void Credit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Credit amount must be greater than zero.");

            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Debit amount must be greater than zero.");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient balance.");

            Balance -= amount;
        }

    }
}
