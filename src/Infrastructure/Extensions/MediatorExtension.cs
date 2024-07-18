using Core.Entities.Base;
using Infrastructure.Persistence.AuthDatabase;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Extensions
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, AuthContext context)
        {
            IEnumerable<EntityEntry<BaseEntity>> domainEntities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            List<INotification> domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (INotification domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}