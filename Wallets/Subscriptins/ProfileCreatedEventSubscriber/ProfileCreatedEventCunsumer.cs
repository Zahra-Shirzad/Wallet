namespace Wallets.Subscriptins.ProfileCreatedEventSubscriber;

public class ProfileCreatedEventCunsumer(WalletService walletService) : IConsumer<ProfileCreatedEvent>
{
    private readonly WalletService _walletService = walletService;

    public async Task Consume(ConsumeContext<ProfileCreatedEvent> context) =>
        await _walletService.CreateDefultWalletAsync(context.Message.profileId);
}
