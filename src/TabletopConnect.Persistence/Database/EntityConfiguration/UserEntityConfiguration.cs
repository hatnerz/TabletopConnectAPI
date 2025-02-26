using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopConnect.Domain.Entities.IAM;

namespace TabletopConnect.Persistence.Database.EntityConfiguration;

internal class UserEntityConfiguration : IdentifiableEntityConfiguration<User, int>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        base.Configure(builder);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.HasIndex(u => u.GoogleId)
            .IsUnique()
            .HasFilter("[Email] IS NOT NULL");
    }
}
