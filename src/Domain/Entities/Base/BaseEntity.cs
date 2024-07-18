using MediatR;

namespace Core.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public List<INotification> DomainEvents { get; } = [];


        public void ClearDomainEvents()
        {
            DomainEvents?.Clear();
        }
    }
}