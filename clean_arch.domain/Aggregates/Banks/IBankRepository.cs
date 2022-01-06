using clean_arch.common.Domain.Seedwork.Interfaces;

namespace clean_arch.domain.Aggregates.Banks
{
    public interface IBankRepository : IWrite<Bank>, IRead<Bank>, IRepository<Bank>
    {
    }
}
