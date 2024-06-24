namespace APBDzad2.Models;

public class ContainerShip
{
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    private List<Container> containers;

    public ContainerShip(double maxSpeed, int maxContainers)
    {
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (containers.Count >= MaxContainers)
            throw new Exception("Cannot load more containers than the maximum allowed.");
        containers.Add(container);
    }

    public void UnloadContainer(Container container)
    {
        containers.Remove(container);
    }

    public double TotalCargoWeight()
    {
        double totalWeight = 0;
        foreach (var container in containers)
        {
            totalWeight += container.CargoWeight;
        }
        return totalWeight;
    }
}