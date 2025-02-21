using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class SubcategoryEntityConfiguration : IdentifiableEntityConfiguration<Subcategory, int>
{
    public override void Configure(EntityTypeBuilder<Subcategory> builder)
    {
        builder.ToTable("Subcategories");

        base.Configure(builder);

        builder.HasMany<BoardGameSubcategory>()
            .WithOne()
            .HasForeignKey(bgs => bgs.SubcategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
