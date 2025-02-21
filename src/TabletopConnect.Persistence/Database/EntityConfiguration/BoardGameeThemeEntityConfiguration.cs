using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGameeThemeEntityConfiguration : IdentifiableEntityConfiguration<BoardGameTheme, int>
{
    public override void Configure(EntityTypeBuilder<BoardGameTheme> builder)
    {
        builder.ToTable("BoardGameThemes");

        base.Configure(builder);
    }
}
