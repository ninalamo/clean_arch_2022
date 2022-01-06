using clean_arch.common.Domain.Seedwork.Interfaces;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace clean_arch.infrastructure.Extensions
{
    internal static class MediatorExtension
    {
        #region Public 
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, ApplicationDbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<IHasDomainEvent>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
        #endregion
    }
}