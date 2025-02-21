using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class BoardGameEntityConfiguration : IdentifiableEntityConfiguration<BoardGame, int>
{
    public override void Configure(EntityTypeBuilder<BoardGame> builder)
    {
        builder.ToTable("BoardGames");

        base.Configure(builder);

        builder.Property(e => e.GameComplexity)
            .HasPrecision(18, 2);


        builder.OwnsOne(e => e.BggData, bggData =>
        {
            bggData.Property(d => d.AverageRating)
                .HasPrecision(18, 2);

            bggData.Property(d => d.BggScore)
                .HasPrecision(18, 2);
        });

        builder.OwnsOne(e => e.PlayTime);
        builder.OwnsOne(e => e.Players, players =>
        {
            var converter = new ValueConverter<List<int>?, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<int>?>(v, (JsonSerializerOptions?)null));

            var comparer = new ValueComparer<List<int>?>(
               (c1, c2) =>
                   (c1 == null && c2 == null) ||
                   (c1 != null && c2 != null && c1.SequenceEqual(c2)),
               c => c == null ? 0 : c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
               c => c == null ? null : new List<int>(c));


           players.Property<List<int>?>("_goodPlayers")
                .HasConversion(converter)
                .Metadata.SetValueComparer(comparer);
        });
        builder.OwnsOne(e => e.RecommendedAge);
        builder.OwnsOne(e => e.BggData);

        builder.HasMany(e => e.BoardGameCategories)
            .WithOne()
            .HasForeignKey(e => e.BoardGameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.BoardGameSubcategories)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.BoardGamePublishers)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.BoardGameDesigners)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.BoardGameThemes)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.BoardGameMechanics)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
