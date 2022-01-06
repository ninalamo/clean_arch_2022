using clean_arch.domain.Aggregates.Banks;
using clean_arch.domain.Aggregates.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace clean_arch.application.Commands.Customers.AddCustomer
{
    public class AddCustomerCommand : IRequest<Guid>
    {
        public Guid BankID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string NameSuffix { get; private set; }

        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }

        public string PIN { get; private set; }
        public decimal Balance { get; private set; }
        public int AccountTypeID { get; private set; }
        public string Number { get; private set; }



    }

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
    {
        private readonly IBankRepository _bankRepository;
        private readonly ILogger<AddCustomerCommandHandler> _logger;

        public AddCustomerCommandHandler(IBankRepository bankRepository, ILogger<AddCustomerCommandHandler> logger)
        {
            _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bank = await _bankRepository.GetAsQueryable()
                    .Include(c => c.Customers)
                    .FirstOrDefaultAsync(c => c.Id == request.BankID, cancellationToken: cancellationToken);

                var customer = new domain.Aggregates.Customers.Customer(
                    request.FirstName,
                    request.LastName,
                    request.MiddleName,
                    request.NameSuffix
                );

                customer.SetAddress(
                    request.AddressLine1,
                    request.AddressLine2,
                    request.City,
                    request.State,
                    request.Country,
                    request.PostalCode
                );


                Random generator = new();
                var PIN = generator.Next(0, 1000000).ToString("D6");

                customer.AddBankAccount(request.Balance, request.AccountTypeID, PIN);

                bank.AddUser(customer);

                await _bankRepository.UpdateAsync(bank);

                return bank.Id;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }

        }
    }
}
