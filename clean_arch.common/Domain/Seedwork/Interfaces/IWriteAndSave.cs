using System;
using System.Threading.Tasks;

namespace clean_arch.common.Domain.Seedwork.Interfaces
{
    public interface IWriteAndSave<T> where T : IAggregateRoot
    {
        Task<Guid> CreateAndSaveAsync(T entity);
        Task<Guid> UpdateAndSaveAsync(T entity);
        Task DeleteAndSaveAsync(T entity);
    }
}
