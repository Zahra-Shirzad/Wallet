namespace Wallets.Shared.Persistance.Entities;

public class Wallet
{
    public int Id { get; set; }
    public Guid ProfileId { get; set; }
    public string Title { get; set; }
    public ICollection<Currency> Currencies { get; set; }

    public Wallet(Guid profileId, string title, Currency[] currencies)
    {
        ProfileId = profileId;
        Title = title;
        Currencies = currencies;
    }
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

        //builder.HasMany<>(x => x.Raito)
        //    .HasPrecision(18, 4)
        //    .IsRequired();

    }

}
