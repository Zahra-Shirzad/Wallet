
namespace Wallets.Controllers.Currencies;

[ApiController]
[Route("Api[controller]")]
public class CurrenciesController : ControllerBase
{
    private readonly WalletDbContext _dbContext;
    private readonly WalletService _walletService;
    public CurrenciesController(WalletDbContext dbContext, WalletService walletService)
    {
        _dbContext = dbContext;
        _walletService = walletService;
    }

    //create
    [HttpPost(Name = "")]
    public async Task<IActionResult> Create(CreateCurrencyRequest request)
    {
        var currency = new Currency(request.Code, request.Name, request.Raito);
        _dbContext.Add(currency);

        return ((await _dbContext.SaveChangesAsync()) > 0)
            switch
        {
            true => Ok(currency),
            false => BadRequest(currency)
        };
    }


    //update
    [HttpPut]
    public async Task<IActionResult> UpdateRetio(UpdateRaitoRequest request)
    {
        var currency = await _dbContext.currencies.FirstOrDefaultAsync(x => x.Raito == request.Raito);

        if (currency is null)
            return BadRequest(currency);

        currency.UpdateRatio(currency.Raito);

        return ((await _dbContext.SaveChangesAsync()) > 0)
            switch
        {
            true => Ok(currency),
            false => BadRequest(currency)
        };
    }


    //getall
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var currency = await _dbContext.currencies
                                    .Select(c => new CurrencyResponse(c.Code, c.Name, c.Raito))
                                    .ToListAsync();

        return currency.Any() switch
        {
            true => Ok(currency),
            false => BadRequest(currency)
        };
    }

    //get/{code}
    [HttpGet("{code}")]
    public async Task<IActionResult> Get([FromRoute] string code)
    {
        var currency = await _dbContext.currencies
                                   .FirstOrDefaultAsync(c => c.Code == code);

        return (currency is not null) switch
        {
            true => Ok(currency),
            false => BadRequest(currency)
        };
    }


    [HttpGet("{code}")]
    public async Task<IActionResult> GetWalletBalance([FromRoute(Name = "wallet-id")] string walletId)
    {
        return null;
    }


}
