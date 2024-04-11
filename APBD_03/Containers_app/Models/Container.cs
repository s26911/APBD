namespace Kontenery_app.Models;

public abstract class Container
{
    public double LoadMassKg { get; protected set; }
    public double OwnWeightKg { get; }
    protected double CapacityKg { get; }
    protected int HeightCm { get; }
    protected int DepthCm { get; }
    public string SerialNumber { get; }

    protected Container(double ownWeightKg, double capacityKg, int heightCm, int depthCm)
    {
        OwnWeightKg = ownWeightKg;
        CapacityKg = capacityKg;
        HeightCm = heightCm;
        DepthCm = depthCm;
        LoadMassKg = 0;
        SerialNumber = GenerateSerialNumber();
    }

    protected abstract string GenerateSerialNumber();

    public abstract void Unload();

    public abstract void Load(double massToLoad);
}