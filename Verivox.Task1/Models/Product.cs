namespace Verivox.Task1.Models;

public abstract class Product
{
    public string TariffName { get; set; }
    public double Cost { get; set; }
    public double AdditionalCost { get; set; }
    public TariffType TariffType { get; init; }
    public abstract double AnnualCosts(double consumption);

    public Product(TariffType tariffType)
    {
        TariffType = tariffType;
    }
}

public class BasicElectricityTariff : Product
{
    public BasicElectricityTariff() : base(TariffType.Basic) { }


    public override double AnnualCosts(double consumption)
    {
        var baseCosts = 12 * Cost;
        var additionalCosts = consumption * AdditionalCost;
        return baseCosts + additionalCosts;
    }
}

public class PackagedElectricityTariff : Product
{
    public PackagedElectricityTariff(double includedKwh) : base(TariffType.Packaged)
    {
        IncludedKwh = includedKwh;
    }

    public double IncludedKwh { get; }

    public override double AnnualCosts(double consumption)
    {
        if (consumption <= IncludedKwh)
        {
            return Cost;
        }

        return Cost + (consumption - IncludedKwh) * AdditionalCost;
    }
}