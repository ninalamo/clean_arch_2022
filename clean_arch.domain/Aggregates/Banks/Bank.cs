using clean_arch.domain.Aggregates.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace clean_arch.domain.Aggregates.Banks
{
    public class Bank
    {
        public string Name { get; private set; }

        private List<Customer> _customers;
        public IReadOnlyCollection<Customer> Customers => _customers.AsReadOnly();


        public Bank(string name)
        {
            Name = name;
            _customers = new();
        }

        #region Behaviors / Methods

        public void AddUser(Customer customer, string pin)
        {
            if (_customers.Any(c => c.Id == customer.Id)) ;
        }

        public void RemoveUser(Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            _customers.Remove(customer);
        }

        public bool FundTransfer(Guid customerId, string pin)

        #endregion

    }
}
