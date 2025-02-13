using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGameEntityConfiguration : IdentifiableEntityConfiguration<BoardGame, int>
{
    public override void Configure(EntityTypeBuilder<BoardGame> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(e => e.BggData);
        builder.OwnsOne(e => e.PlayTime);
        builder.OwnsOne(e => e.RecommendedPlayers, players =>
        {
            var converter = new ValueConverter<List<int>?, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<int>?>(v, (JsonSerializerOptions?)null));

            players.Property(p => p.BestPlayers)
                .HasConversion(converter);
        });
        builder.OwnsOne(e => e.RecommendedAge);
        builder.OwnsOne(e => e.BggData);
    }
}
