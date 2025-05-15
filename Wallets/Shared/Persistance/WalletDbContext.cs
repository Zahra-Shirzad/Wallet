
namespace Wallets.Shared.Persistance;

public class WalletDbContext(DbContextOptions<WalletDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Currency> currencies { get; set; }
    public DbSet<Wallet> wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyMarker.ApplicationAssembly);
    }
}
