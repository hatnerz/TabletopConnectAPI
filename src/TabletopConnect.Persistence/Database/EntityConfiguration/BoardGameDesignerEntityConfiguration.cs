using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGameDesignerEntityConfiguration : IdentifiableEntityConfiguration<BoardGameDesigner, int>
{
    public override void Configure(EntityTypeBuilder<BoardGameDesigner> builder)
    {
        builder.ToTable("BoardGameDesigners");

        base.Configure(builder);
    }
}
