using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGameMechanicEntityConfiguration : IdentifiableEntityConfiguration<BoardGameMechanics, int>
{
    public override void Configure(EntityTypeBuilder<BoardGameMechanics> builder)
    {
        builder.ToTable("BoardGameMechanics");

        base.Configure(builder);
    }
}
