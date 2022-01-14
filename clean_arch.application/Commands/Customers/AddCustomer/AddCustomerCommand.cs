using clean_arch.domain.Aggregates.Customers;
using MediatR;
using System;
using System.Linq;

namespace clean_arch.application.Commands.Customers.AddCustomer
{
    public class AddCustomerCommand : IRequest<Guid>
    {
        public Guid BankID { get;init; }
        public string FirstName { get;init; }
        public string LastName { get;init; }
        public string MiddleName { get;init; }
        public string NameSuffix { get;init; }

        public string AddressLine1 { get;init; }
        public string AddressLine2 { get;init; }
        public string City { get;init; }
        public string State { get;init; }
        public string Country { get;init; }
        public string PostalCode { get;init; }

        public string PIN { get;init; }
        public decimal Balance { get;init; }
        public int AccountTypeID { get;init; }
        public string Number { get;init; }



    }
}
