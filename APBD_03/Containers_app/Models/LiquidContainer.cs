namespace Kontenery_app.Models;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsDangerous { get; }
    private static int SerialNumberIndex { get; set; } = 1;


    public LiquidContainer(double ownWeightKg, double capacityKg, int heightCm, int depthCm, bool isDangerous) : base(
        ownWeightKg, capacityKg, heightCm, depthCm)
    {
        IsDangerous = isDangerous;
    }

    protected override string GenerateSerialNumber()
    {
        return "KON-L-" + SerialNumberIndex++;
    }

    public override void Unload()
    {
        LoadMassKg = 0;
    }

    public override void Load(double massToLoad)
    {
        if (IsDangerous && massToLoad > 0.5 * CapacityKg)
            HazardWarning("Attempt to fill container with dangerous load type over 50% of its capacity!");
        else if (massToLoad > 0.9 * CapacityKg)
            HazardWarning("Attempt to fill container over 90% of its capacity!");
        else
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
                             "\nDangerous:\t\t{6}\n", SerialNumber, LoadMassKg, OwnWeightKg, CapacityKg, HeightCm,
            DepthCm, IsDangerous);
    }
}