using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class MechanicEntityConfiguration : IdentifiableEntityConfiguration<Mechanic, int>
{
    public override void Configure(EntityTypeBuilder<Mechanic> builder)
    {
        builder.ToTable("Mechanics");

        base.Configure(builder);

        builder.HasMany<BoardGameMechanic>()
            .WithOne()
            .HasForeignKey(bgm => bgm.MechanicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
