namespace Wallets.Controllers.Currencies.Dtos;

public record CreateCurrencyRequest(
    string Code,
    string Name,
    decimal Raito
);
