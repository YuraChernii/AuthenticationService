using Core.Entities;
using Core.Entities.Base;
using Infrastructure.Extensions;
using Infrastructure.Persistence.AuthDatabase.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.AuthDatabase
{
    public class AuthContext : DbContext
    {
        private readonly IMediator mediator;
        private readonly ILogger logger;

        public AuthContext(
            DbContextOptions<AuthContext> options, 
            IMediator mediator,
            ILoggerFactory loggerFactory) : base(options)
        {
            this.mediator = mediator;
            logger = loggerFactory.CreateLogger<AuthContext>();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserEntityConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetUtcFormat();
            await base.SaveChangesAsync(cancellationToken);

            try
            {
                await mediator.DispatchDomainEventsAsync(this);
                SetUtcFormat();

                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger?.LogError($"Error occurred on domain events publish: {ex.Message}");
                throw;
            }
        }

        private void SetUtcFormat()
        {
            IEnumerable<EntityEntry> modifiedEntries = ChangeTracker.Entries()
               .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            DateTime now = DateTime.UtcNow;
            foreach (EntityEntry entry in modifiedEntries)
            {
                if (entry.Entity is not BaseEntity entity)
                {
                    continue;
                }

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedOn = now;
                }

                entity.ModifiedOn = now;
            }
        }
    }
}