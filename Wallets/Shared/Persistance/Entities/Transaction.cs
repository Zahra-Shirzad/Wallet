namespace Wallets.Shared.Persistance.Entities;

public class Transaction
{
    public int Id { get; set; }
    public int WalletId { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public string CurrencyCode { get; set; }
}
