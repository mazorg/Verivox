using Verivox.Task1.Models;

namespace Verivox.Task1;

public interface IExternalServiceMock
{
    public Task<IEnumerable<Product>> Get(CancellationToken cancellationToken = default);
}

public class ExternalServiceMock : IExternalServiceMock
{
    private readonly Product[] _products =
    {
        new BasicElectricityTariff
        {
            Cost = 5, AdditionalCost = 0.22, TariffName = "Product A"
        },
        new PackagedElectricityTariff(4000)
        {
            Cost = 800, AdditionalCost = 0.3, TariffName = "Product B"
        }
    };

    public async Task<IEnumerable<Product>> Get(CancellationToken cancellationToken)
    {
        // Adding some delay to mimic external service request time. 
        var random = new Random();
        await Task.Delay(random.Next(2000), cancellationToken);

        return !cancellationToken.IsCancellationRequested ? _products : Enumerable.Empty<Product>();
    }
}