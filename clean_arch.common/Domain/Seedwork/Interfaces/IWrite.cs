using System;
using System.Threading.Tasks;

namespace clean_arch.common.Domain.Seedwork.Interfaces
{
    public interface IWrite<T> where T : IAggregateRoot
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
