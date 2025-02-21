using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGameCategoryEntityConfiguration : IdentifiableEntityConfiguration<BoardGameCategory, int>
{
    public override void Configure(EntityTypeBuilder<BoardGameCategory> builder)
    {
        builder.ToTable("BoardGameCategories");

        base.Configure(builder);
    }
}
