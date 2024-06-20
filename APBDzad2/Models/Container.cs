using APBDzad2.Models.Exceptions;

namespace APBDzad2.Models;

public abstract class Container
{
    private static int _serialNumberCounter = 1;
    public string SerialNumber { get; set; }
    public double CargoWeight { get; set; }
    public double EmptyWeight { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double MaxLoadCapacity { get; set; }
    public string ContainerType { get; set; }
    
    public Container (double emptyWeight, double height, double depth, double maxLoadCapacity, string containerType)
    {
        EmptyWeight = emptyWeight;
        Height = height;
        Depth = depth;
        MaxLoadCapacity = maxLoadCapacity;
        ContainerType = containerType;
        SerialNumber = $"KON-{containerType}-{_serialNumberCounter++}";
    }
    
    public virtual void Load(double weight)
    {
        if (CargoWeight + weight > MaxLoadCapacity)
            throw new OverFillException("Cannot load more than the maximum load capacity.");
        CargoWeight += weight;
    }

    public virtual void Unload()
    {
        CargoWeight = 0;
    }
}