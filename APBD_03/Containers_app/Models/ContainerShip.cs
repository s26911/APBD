namespace Kontenery_app.Models;

public class ContainerShip
{
    private List<Container> _containers;
    private double MaxSpeedKnots { get; }
    private int MaxContainersCount { get; }
    private double MaxContainersMass { get; }
    private string SerialNumber { get; }
    private static int _index = 1;

    public ContainerShip(double maxSpeedKnots, int maxContainersCount, double maxContainersMass)
    {
        MaxSpeedKnots = maxSpeedKnots;
        MaxContainersCount = maxContainersCount;
        MaxContainersMass = maxContainersMass;
        _containers = new List<Container>();
        SerialNumber = "S-" + _index++;
    }

    public bool LoadContainer(Container container)
    {
        if (_containers.Contains(container))
            Console.WriteLine("This container is already on ship");
        else if (_containers.Count >= MaxContainersCount)
            Console.WriteLine("Container ship is full and cannot load more containers!(COUNT)");
        else
        {
            double weight = 0;
            _containers.ForEach(c => weight += c.LoadMassKg + c.OwnWeightKg);

            if (weight + container.OwnWeightKg + container.LoadMassKg > MaxContainersMass)
                Console.WriteLine("Container ship is full and cannot load more containers!(MASS)");
            else
            {
                _containers.Add(container);
                return true;
            }
        }

        return false;
    }

    public void LoadContainer(List<Container> containers)
    {
        foreach (var c in containers)
        {
            LoadContainer(c);
        }
    }

    public void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }

    public Container? RemoveContainer(string serialNum)
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].SerialNumber == serialNum)
            {
                Container container = _containers[i];
                _containers.Remove(container);
                return container;
            }
        }

        return null;
    }

    public void ReplaceContainer(string onShip, Container toReplace)
    {
        Container? removed = RemoveContainer(onShip);
        if (removed == null)
        {
            Console.WriteLine("Container to be replaced was not found on ship");
            return;
        }

        if (!LoadContainer(toReplace)) // adding the container
        {
            Console.WriteLine("Given container couldn't fit on ship! Aborting...");
            LoadContainer(removed);
        }
    }

    public void MoveContainerBetweenShips(ContainerShip target, string toMoveSerialNum)
    {
        Container? removed = RemoveContainer(toMoveSerialNum);
        if (removed == null)
        {
            Console.WriteLine("Container to be replaced was not found on ship");
            return;
        }

        if (!target.LoadContainer(removed)) // adding the container
        {
            Console.WriteLine("Given container couldn't fit on target ship! Aborting...");
            LoadContainer(removed);
        }
    }

    public override string ToString()
    {
        String s = "Container ship " + SerialNumber + ":" +
                   "\nMax speed [knots]: " + MaxSpeedKnots +
                   "\nMax containers count: " + MaxContainersCount +
                   "\nMax containers mass [kg]: " + MaxContainersMass +
                   "\nContents:";
        foreach (var c in _containers)
        {
            s += "\n\t" + c.SerialNumber;
        }

        return s + "\n";
    }
}