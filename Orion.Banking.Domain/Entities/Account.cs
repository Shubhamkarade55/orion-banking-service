using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orion.Banking.Domain.Entities
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        [Column("AccountId")]
        public Guid Id { get; private set; }

        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; private set; }

        [Required]
        [MaxLength(100)]
        public string HolderName { get; private set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; private set; }

        // ✅ Required by EF Core
        protected Account() { }

        // ✅ Domain constructor
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