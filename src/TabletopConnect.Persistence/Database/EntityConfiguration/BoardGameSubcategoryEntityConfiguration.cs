using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGameSubcategoryEntityConfiguration : IdentifiableEntityConfiguration<BoardGameSubcategory, int>
{
    public override void Configure(EntityTypeBuilder<BoardGameSubcategory> builder)
    {
        builder.ToTable("BoardGameSubcategories");

        base.Configure(builder);
    }
}
