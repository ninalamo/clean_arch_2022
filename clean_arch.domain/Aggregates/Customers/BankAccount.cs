using clean_arch.common.Domain.Seedwork;
using System;

namespace clean_arch.domain.Aggregates.Customers
{
    public class BankAccount : BaseEntity
    {
        public DateTimeOffset LastTransactionDate { get; private set; }
        public string PIN { get; private set; }

        public decimal Balance { get; private set; }
        public Guid AccountTypeID { get; private set; }
        public string Number { get; private set; }

        public BankAccount AccountType { get; private set; }

        public BankAccount()
        {
            Random generator = new Random();
            PIN = generator.Next(0, 1000000).ToString("D6");
        }


        #region Behaviors /Methods

        public void Withdraw(decimal amount)
        {
            if (Balance - amount < 0)
            {
                throw new Exception("Insufficent funds.");
            }

            Balance -= amount;
            LastTransactionDate = DateTimeOffset.Now;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            LastTransactionDate = DateTimeOffset.Now;
        }

        public void BalanceInquiry()
        {
            LastTransactionDate = DateTimeOffset.Now;
        }

        public void ResetPIN(string oldPIN, string newPIN)
        {
            if (oldPIN == PIN)
            {
                PIN = newPIN;
            }

            throw new Exception("Invalid PIN. Cannot process.");
        }

        #endregion
    }
}
