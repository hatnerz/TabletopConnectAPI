using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGameMechanicEntityConfiguration : IdentifiableEntityConfiguration<BoardGameMechanic, int>
{
    public override void Configure(EntityTypeBuilder<BoardGameMechanic> builder)
    {
        builder.ToTable("BoardGameMechanics");

        base.Configure(builder);
    }
}
