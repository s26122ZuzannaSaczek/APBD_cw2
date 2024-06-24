using APBDzad2.Models;
using APBDzad2.Models.Exceptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            ContainerShip ship = new ContainerShip(30, 5);
            
            LiquidContainer milkContainer = new LiquidContainer(1000, 200, 100, 10000, false);
            GasContainer oxygenContainer = new GasContainer(500, 150, 80, 5000, 10, true);
            RefrigeratedContainer appleContainer = new RefrigeratedContainer(1200, 220, 110, 8000, "Apples", -2);

            // Loading containers
            milkContainer.Load(8000); 
            oxygenContainer.Load(2000); 
            
            //attempt to overfill hazardous material
            //oxygenContainer.Load(3000); 
            appleContainer.LoadProduct("Apples", 7000, -1); 
            
            //shipping containers
            ship.LoadContainer(milkContainer);
            ship.LoadContainer(oxygenContainer);
            ship.LoadContainer(appleContainer);
            
            Console.WriteLine($"Total cargo weight on the ship: {ship.TotalCargoWeight()} kg");

        }
        catch (OverFillException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}