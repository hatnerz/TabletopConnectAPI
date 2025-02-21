using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class ThemeEntityConfiguration : IdentifiableEntityConfiguration<Theme, int>
{
    public override void Configure(EntityTypeBuilder<Theme> builder)
    {
        builder.ToTable("Themes");

        base.Configure(builder);

        builder.HasMany<BoardGameTheme>()
            .WithOne()
            .HasForeignKey(bgt => bgt.ThemeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
