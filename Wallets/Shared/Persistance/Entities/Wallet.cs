namespace Wallets.Shared.Persistance.Entities;

public class Wallet
{
    public int Id { get; set; }
    public Guid ProfileId { get; set; }
    public string Title { get; set; }
    public WalletStatus Status { get; set; }
    public Currency Currency { get; set; }
    public string CurrencyCode { get; set; }

    public Wallet(Guid profileId, string title, string currencycode)
    {
        ProfileId = profileId;
        Title = title;
        Status = WalletStatus.Active;
        CurrencyCode = currencycode;
    }

    public void Active() =>
        Status = WalletStatus.Active;

    public void Ban() =>
        Status = WalletStatus.Banned;

    public void Suspend() =>
        Status = WalletStatus.Suspend;

 }

public enum WalletStatus
{
    Active,
    Inactive,
    Suspend,
    Banned
}

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProfileId)
               .IsRequired();

        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
            }

}
