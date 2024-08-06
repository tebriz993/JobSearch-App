using JobSearchManagementSystem.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.Interceptors
{
    public class UpdateBaseEntityInterceptor:SaveChangesInterceptor
    {
        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            var dbContext = eventData.Context;

            if (dbContext is null)
            {
                return base.SavedChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<BaseEntity>> entities = dbContext
                .ChangeTracker
                .Entries<BaseEntity>();



            foreach (var entityEntry in entities)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.Property(x => x.CreatedDate).CurrentValue = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entityEntry.Property(x => x.UpdatedDate).CurrentValue = DateTime.UtcNow;
                        break;
                }
            }

            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}
