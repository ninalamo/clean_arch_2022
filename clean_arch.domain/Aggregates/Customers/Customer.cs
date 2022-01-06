﻿using clean_arch.common.Domain.Seedwork;
using clean_arch.common.Domain.Seedwork.Interfaces;
using clean_arch.domain.ValueObjects;
using SAFRA.SMCMS.SharedKernel.Domain.SeedWork;
using System.Collections.Generic;

namespace clean_arch.domain.Aggregates.Customers
{
    public class Customer : DomainEntity, IAggregateRoot
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string NameSuffix { get; private set; }

        public Address Address { get; private set; }

        private List<BankAccount> _bankAccounts;
        public IReadOnlyCollection<BankAccount> BankAccounts => _bankAccounts.AsReadOnly();


        #region Ctor

        protected Customer()
        {
            Address = new Address();
        }

        public Customer(string firstName, string lastName, string middleName, string nameSuffix)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            NameSuffix = nameSuffix;
        }

        #endregion

        #region Behaviors / Methods

        public void SetName(string firstName, string lastName, string middleName, string nameSuffix)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            NameSuffix = nameSuffix;
        }

        public string GetFullName() => $"{FirstName} {MiddleName} {LastName} {NameSuffix}";

        public void SetAddress(string addressLine1, string addressLine2, string city, string state, string country, string postalCode)
        {
            if (Address == default) Address = new Address(addressLine1, addressLine2, city, state, country, postalCode);
        }

        #endregion
    }

    public class UserAccount : ValueObject
    {
        public string U
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }


}