namespace Wallets.Services;

public class WalletService
{
    private readonly WalletDbContext _dbContext;
    private readonly string DefultWalletName = "کیف پول الکترونیکی";
    public WalletService(WalletDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task CreateDefultWalletAsync(Guid ProfileId)
    {
        var haswallet = await _dbContext.wallets.AnyAsync(w => w.ProfileId == ProfileId);

        if (haswallet) return;

        var wallet = new Wallet(ProfileId, DefultWalletName, "IRR");

        await _dbContext.wallets.AddAsync(wallet);
        await _dbContext.SaveChangesAsync();
    }
}
