using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class FavouriteGameEntityConfiguration : IdentifiableEntityConfiguration<FavouriteGame, int>
{
    public override void Configure(EntityTypeBuilder<FavouriteGame> builder)
    {
        builder.ToTable("FavouriteGames");

        base.Configure(builder);

        builder
            .HasOne<PlayerProfile>()
            .WithMany()
            .HasForeignKey(fg => fg.PlayerProfileId);

        builder
            .HasOne<BoardGame>()
            .WithMany()
            .HasForeignKey(fg => fg.BoardGameId);
    }
}
