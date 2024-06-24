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

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(double emptyWeight, double height, double depth, double maxLoadCapacity, string productType, double temperature)
        : base(emptyWeight, height, depth, maxLoadCapacity, "C")
    {
        ProductType = productType;
        Temperature = temperature;
    }

    public void SetTemperature(double temperature)
    {
        if (temperature < Temperature)
            throw new Exception("The temperature cannot be set lower than required by the product.");
        Temperature = temperature;
    }

    public void LoadProduct(string productType, double weight, double temperature)
    {
        if (productType != ProductType)
            throw new Exception("Cannot mix different types of products in the same container.");

        SetTemperature(temperature);
        base.Load(weight);
    }
}

public class LiquidContainer : Container
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double emptyWeight, double height, double depth, double maxLoadCapacity, bool isHazardous)
        : base(emptyWeight, height, depth, maxLoadCapacity, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        if (IsHazardous && weight > MaxLoadCapacity * 0.5)
            throw new OverFillException("Hazardous liquid containers can only be filled up to 50% of their capacity.");
        else if (!IsHazardous && weight > MaxLoadCapacity * 0.9)
            throw new OverFillException("Non-hazardous liquid containers can only be filled up to 90% of their capacity.");
        
        base.Load(weight);
    }
}
public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    public bool IsHazardous { get; set; }

    public GasContainer(double emptyWeight, double height, double depth, double maxLoadCapacity, double pressure, bool isHazardous)
        : base(emptyWeight, height, depth, maxLoadCapacity, "G")
    {
        Pressure = pressure;
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        if (IsHazardous && weight > MaxLoadCapacity * 0.5)
        {
            NotifyHazard($"Attempt to overfill hazardous gas container {SerialNumber}");
            throw new OverFillException("Hazardous gas containers can only be filled up to 50% of their capacity.");
        }
        else if (!IsHazardous && weight > MaxLoadCapacity * 0.9)
        {
            NotifyHazard($"Attempt to overfill non-hazardous gas container {SerialNumber}");
            throw new OverFillException("Non-hazardous gas containers can only be filled up to 90% of their capacity.");
        }

        base.Load(weight);
    }

    public override void Unload()
    {
        CargoWeight *= 0.05; 
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification: {message}");
    }
}
