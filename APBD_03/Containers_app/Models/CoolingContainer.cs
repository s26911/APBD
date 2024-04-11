using Kontenery_app.Exceptions;

namespace Kontenery_app.Models;

public class CoolingContainer : Container
{
    private string Type { get; }
    private double Temperature { get; set; }
    private static int SerialNumberIndex { get; set; } = 1;


    private readonly Dictionary<string, double> _productsTemperatures = new Dictionary<string, double>()
    {
        { "bananas", 13.3 }, { "chocolate", 18 }, { "fish", 2 },
        { "meat", -15 }, { "ice cream", -18 }, { "frozen pizza", -30 },
        { "cheese", 7.2 }, { "sausages", 5 }, { "butter", 20.5 },
        { "eggs", 19 }
    };

    public CoolingContainer(double ownWeightKg, double capacityKg, int heightCm, int depthCm, string type,
        double temperature) : base(ownWeightKg, capacityKg, heightCm, depthCm)
    {
        Type = type;
        Temperature = temperature;
    }


    protected override string GenerateSerialNumber()
    {
        return "KON-C-" + SerialNumberIndex++;
    }

    public override void Unload()
    {
        LoadMassKg = 0;
    }

    public override void Load(double massToLoad)
    {
        if (massToLoad > CapacityKg)
            throw new OverfillException();

        LoadMassKg = massToLoad;
    }

    public void LoadWithCheck(double mass, string productType)
    {
        if (productType.ToLower() != Type)
            throw new IncorrectProductTypeException();
        if (Temperature > _productsTemperatures[Type])
            throw new TemperatureTooHighException(Type, _productsTemperatures[Type]);

        Load(mass);
    }

    public override string ToString()
    {
        return String.Format("Gas container nr. {0}" +
                             "\nLoad mass [kg]:\t\t{1}" +
                             "\nOwn weight [kg]:\t{2}" +
                             "\nCapacity [kg]:\t\t{3}" +
                             "\nHeight [cm]:\t\t{4}" +
                             "\nDepth [cm]:\t\t{5}" +
                             "\nType [atm]:\t\t{6}" +
                             "\nTemperature [\u00b0C]:\t{7}\n", SerialNumber, LoadMassKg, OwnWeightKg, CapacityKg,
            HeightCm, DepthCm, Type, Temperature);
    }
}