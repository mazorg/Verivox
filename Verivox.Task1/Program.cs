using Verivox.Task1;
using Verivox.Task1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IExternalServiceMock, ExternalServiceMock>();

var app = builder.Build();

app.MapGet("annualCosts/{consumption}",
    async (double consumption, IExternalServiceMock service, CancellationToken cancellationToken) =>
    {
        if (consumption < 0) return Results.BadRequest("Consumption must be valid Positive number.");
        var products = await service.Get(cancellationToken);
        return Results.Ok(products.Select(p => new { p.TariffName, AnnualCosts = p.AnnualCosts(consumption) }));
    });

app.Run();