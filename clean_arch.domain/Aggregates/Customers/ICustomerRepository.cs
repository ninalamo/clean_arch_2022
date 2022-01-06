using clean_arch.common.Domain.Seedwork.Interfaces;

namespace clean_arch.domain.Aggregates.Customers
{
    public interface ICustomerRepository : IRead<Customer>, IWrite<Customer>, IRepository<Customer>
    {

    }
}
