using System;
using System.Linq;
using System.Threading.Tasks;

namespace clean_arch.common.Domain.Seedwork.Interfaces
{
    public interface IRead<T> where T : IAggregateRoot
    {
        IQueryable<T> GetAsQueryable();
        //Task<(List<T>, int)> GetListAsync(SieveModel request);
        Task<T> GetByIdAsync(Guid id);
    }
}
