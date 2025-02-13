using Microsoft.EntityFrameworkCore;

namespace TabletopConnect.Persistence.Database;

public class TabletopDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabletopDbContext).Assembly);
    }
}
