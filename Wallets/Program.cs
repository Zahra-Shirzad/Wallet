using Wallets.Shared;
using Wallets.Subscriptins.ProfileCreatedEventSubscriber;

var builder = WebApplication.CreateBuilder(args);
BrokerConfigure(builder);

builder.Services.AddDbContext<WalletDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("svcDbContext"));


});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<WalletService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("CreateAProfile", async (IPublishEndpoint publisher) =>
{
    await publisher.Publish(new ProfileCreatedEvent(Guid.NewGuid()));
});

app.Run();


static void BrokerConfigure(IHostApplicationBuilder builder)
{
    builder.Services.AddMassTransit(configure =>
    {
        configure.AddConsumers(AssemblyMarker.ApplicationAssembly);
        configure.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("localhost", HostConfigure =>
            {
                HostConfigure.Username("guest");
                HostConfigure.Password("guest");
            });
            cfg.ConfigureEndpoints(context);
        });
    });

}


