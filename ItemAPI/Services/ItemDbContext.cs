using Microsoft.EntityFrameworkCore;

namespace ItemAPI;

public class ItemDbContext : DbContext
{
    public DbSet<Items> Items { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=ItemDb;");
        
    }

}
