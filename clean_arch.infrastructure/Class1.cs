using clean_arch.common.Domain.Seedwork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace clean_arch.infrastructure
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
