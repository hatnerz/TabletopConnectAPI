using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal abstract class IdentifiableEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity<TKey>
    where TKey : struct
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
    }
}
