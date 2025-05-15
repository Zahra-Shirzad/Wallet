
namespace Wallets.Shared.Persistance.Entities;

public class Currency
{
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Raito { get; set; }
    public DateTime ModifiedAtUtc { get; set; }
    public ICollection<Wallet> Wallets { get; set; }

    public Currency(string code, string name, decimal raito)
    {
        Code = code;
        Name = name;
        Raito = raito;
        ModifiedAtUtc = DateTime.UtcNow;
    }

    public void UpdateRatio(decimal ratio)
    {
        ModifiedAtUtc = DateTime.UtcNow;
        Raito = ratio;
    }

}





public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(x => x.Code);

        builder.Property(x => x.Code)
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Raito)
            .HasPrecision(10, 9)
            .IsRequired();


    }

}