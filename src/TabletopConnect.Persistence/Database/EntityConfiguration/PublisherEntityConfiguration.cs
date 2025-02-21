using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class PublisherEntityConfiguration : IdentifiableEntityConfiguration<Publisher, int>
{
    public override void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publishers");

        base.Configure(builder);

        builder.HasMany<BoardGamePublisher>()
            .WithOne()
            .HasForeignKey(bgp => bgp.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
