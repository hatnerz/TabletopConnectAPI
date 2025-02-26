using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;
using TabletopConnect.Domain.Entities.IAM;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;
internal class PlayerProfileEntityConfiguration : IdentifiableEntityConfiguration<PlayerProfile, int>
{
    public override void Configure(EntityTypeBuilder<PlayerProfile> builder)
    {
        builder.ToTable("PlayerProfiles");

        base.Configure(builder);

        builder.HasOne<User>()
            .WithOne()
            .HasForeignKey<PlayerProfile>(pp => pp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
