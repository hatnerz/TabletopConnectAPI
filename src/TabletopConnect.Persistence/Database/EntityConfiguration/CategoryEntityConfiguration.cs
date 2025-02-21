using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class CategoryEntityConfiguration : IdentifiableEntityConfiguration<Category, int>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        base.Configure(builder);

        builder.HasMany<BoardGameCategory>()
            .WithOne()
            .HasForeignKey(bgc => bgc.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
