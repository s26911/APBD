using Kontenery_app.Exceptions;

namespace Kontenery_app.Models;

public class GasContainer : Container, IHazardNotifier
{
    private double Pressure { get; }
    private static int SerialNumberIndex { get; set; } = 1;


    public GasContainer(double ownWeightKg, double capacityKg, int heightCm, int depthCm, double pressure) : base(
        ownWeightKg, capacityKg, heightCm, depthCm)
    {
        Pressure = pressure;
    }

    protected override string GenerateSerialNumber()
    {
        return "KON-G-" + SerialNumberIndex++;
    }

    public override void Unload()
    {
        if (LoadMassKg > CapacityKg * 0.05)
            LoadMassKg = CapacityKg * 0.05;
        else
            HazardWarning("Attempt to empty gas container below its 5% capacity!");
    }

    public override void Load(double massToLoad)
    {
        if (massToLoad > CapacityKg)
            throw new OverfillException();

        LoadMassKg = massToLoad;
    }

    public void HazardWarning(string info)
    {
        Console.WriteLine("HAZARD WARNING: " + info);
    }

    public override string ToString()
    {
        return String.Format("Gas container nr. {0}" +
                             "\nLoad mass [kg]:\t\t{1}" +
                             "\nOwn weight [kg]:\t{2}" +
                             "\nCapacity [kg]:\t\t{3}" +
                             "\nHeight [cm]:\t\t{4}" +
                             "\nDepth [cm]:\t\t{5}" +
                             "\nPressure [atm]:\t\t{6}\n", SerialNumber, LoadMassKg, OwnWeightKg, CapacityKg, HeightCm,
            DepthCm, Pressure);
    }
}