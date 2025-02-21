using Microsoft.EntityFrameworkCore;

namespace TabletopConnect.Persistence.Database;

public class TabletopDbContext : DbContext
{
    public TabletopDbContext()
    {
    }

    public TabletopDbContext(DbContextOptions<TabletopDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabletopDbContext).Assembly);
    }
}
