using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class DesignerEntityConfiguration : IdentifiableEntityConfiguration<Designer, int>
{
    public override void Configure(EntityTypeBuilder<Designer> builder)
    {
        builder.ToTable("Designers");

        base.Configure(builder);

        builder.HasMany<BoardGameDesigner>()
            .WithOne()
            .HasForeignKey(bgd => bgd.DesignerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
