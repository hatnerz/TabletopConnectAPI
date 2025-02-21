using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGamePublisherEntityConfiguration : IdentifiableEntityConfiguration<BoardGamePublisher, int>
{
    public override void Configure(EntityTypeBuilder<BoardGamePublisher> builder)
    {
        builder.ToTable("BoardGamePublishers");

        base.Configure(builder);
    }
}
