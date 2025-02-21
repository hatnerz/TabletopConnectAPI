using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class FamilyEntityConfiguration : IdentifiableEntityConfiguration<Family, int>
{
    public override void Configure(EntityTypeBuilder<Family> builder)
    {
        builder.ToTable("Families");

        base.Configure(builder);

        builder.HasMany<BoardGame>()
            .WithOne()
            .HasForeignKey(bg => bg.FamilyId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
