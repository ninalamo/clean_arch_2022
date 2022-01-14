using clean_arch.common.Domain.Seedwork;
using clean_arch.domain.Aggregates.BankAccountTypes;
using System;

namespace clean_arch.domain.Aggregates.Customers
{
    public class BankAccount : BaseEntity
    {
        public string PIN { get; private set; }
        public decimal Balance { get; private set; }
        public int AccountTypeID { get; private set; }
        public string Number { get; private set; }

        public BankAccountType AccountType { get; private set; }

        public BankAccount()
        {
            Random generator = new Random();
            PIN = generator.Next(0, 1000000).ToString("D6");
        }

        public BankAccount(decimal initialDeposit, int accountType, string PIN)
        {
            Balance = initialDeposit;
            AccountTypeID = accountType;
        }


        #region Behaviors /Methods

        public void Withdraw(decimal amount)
        {
            if (Balance - amount < 0)
            {
                throw new Exception("Insufficent funds.");
            }

            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
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
