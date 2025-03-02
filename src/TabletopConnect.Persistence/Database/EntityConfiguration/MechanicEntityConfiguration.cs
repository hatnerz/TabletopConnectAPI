using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class MechanicEntityConfiguration : IdentifiableEntityConfiguration<Mechanics, int>
{
    public override void Configure(EntityTypeBuilder<Mechanics> builder)
    {
        builder.ToTable("Mechanics");

        base.Configure(builder);

        builder.HasMany<BoardGameMechanics>()
            .WithOne()
            .HasForeignKey(bgm => bgm.MechanicsId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
