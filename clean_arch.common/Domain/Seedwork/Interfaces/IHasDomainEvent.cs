using MediatR;
using System.Collections.Generic;

namespace clean_arch.common.Domain.Seedwork.Interfaces
{
    public interface IHasDomainEvent
    {
        IReadOnlyCollection<INotification> DomainEvents
        {
            get;
        }

        void AddDomainEvent(INotification eventItem);

        void ClearDomainEvents();

        void RemoveDomainEvent(INotification eventItem);
    }
}
