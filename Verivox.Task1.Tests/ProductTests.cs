using Verivox.Task1.Models;

namespace Verivox.Task1.Tests;

public class ProductTests
{
    private readonly Product _productA = new BasicElectricityTariff
    {
        Cost = 5, AdditionalCost = 0.22, TariffName = "Product A"
    };

    private readonly Product _productB = new PackagedElectricityTariff(4000)
    {
        Cost = 800, AdditionalCost = 0.3, TariffName = "Product B"
    };


    [Theory]
    [InlineData(3500, 830)]
    [InlineData(4500, 1050)]
    public void BasicElectricityTariff_Should_Calculate_BasePlusAdditionalCosts(double consumption,
        double expectedAnnualCosts)
    {
        var annualCosts = _productA.AnnualCosts(consumption);
        Assert.Equal(expectedAnnualCosts, annualCosts);
    }

    [Theory]
    [InlineData(3500, 800)]
    [InlineData(4500, 950)]
    public void PackagedElectricityTariff_Should_Calculate_AdditionalCostsAfterIncludedKwhPassed(double consumption,
        double expectedAnnualCosts)
    {
        var annualCosts = _productB.AnnualCosts(consumption);
        Assert.Equal(expectedAnnualCosts, annualCosts);
    }
}