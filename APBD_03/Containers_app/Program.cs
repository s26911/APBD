using Kontenery_app.Models;

namespace Kontenery_app;

class Program
{
    public static void Main(string[] args)
    {
        // Creating containers ########################################################################
        LiquidContainer liquidContainer1 = new LiquidContainer(1000, 3000, 100, 400, false);
        LiquidContainer liquidContainer2 = new LiquidContainer(500, 2000, 100, 200, true);
        GasContainer gasContainer1 = new GasContainer(1200, 4200, 150, 350, 4);
        GasContainer gasContainer2 = new GasContainer(1600, 5000, 200, 350, 5);
        CoolingContainer coolingContainer1 = new CoolingContainer(4000, 8000, 300, 600, "chocolate", 15);
        CoolingContainer coolingContainer2 = new CoolingContainer(3000, 5000, 200, 500, "bananas", 30);

        ContainerShip ship = new ContainerShip(100, 3, 10000);
        ContainerShip ship2 = new ContainerShip(100, 3, 10000);
        // Loading containers ########################################################################
        // Liquid containers #######################################
        // Unsuccessful
        // liquidContainer1.Load(999999999);
        // Console.WriteLine(liquidContainer1);
        // liquidContainer2.Load(999999999);
        // Console.WriteLine(liquidContainer2);

        // Successful
        liquidContainer1.Load(2500);
        // Console.WriteLine(liquidContainer1);
        liquidContainer2.Load(900);
        // Console.WriteLine(liquidContainer2);

        // Gas containers ###########################################
        // Unsuccessful
        // try
        // {
        //     gasContainer1.Load(999999999);
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e.Message);
        // }

        // Successful
        gasContainer1.Load(2500);
        // Console.WriteLine(gasContainer1);

        // Cooling containers ######################################
        // Unsuccessful
        // try
        // {
        // coolingContainer1.LoadWithCheck(999999999, "chocolate");     // too much
        // coolingContainer1.LoadWithCheck(500, "meat");                // wrong type 
        // coolingContainer2.LoadWithCheck(500, "bananas"); // too hot
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e.Message);
        // }
        //
        // // Successful
        coolingContainer1.LoadWithCheck(1000, "chocolate");
        // Console.WriteLine(coolingContainer1);


        // Loading containers on ship ###################################################################
        ship.LoadContainer(liquidContainer1);
        ship.LoadContainer(liquidContainer2);
        // ship.LoadContainer(coolingContainer1);
        // ship.LoadContainer(coolingContainer2);

        // Loading list of containers on ship ##########################################################
        // ship.LoadContainer(new List<Container>(){liquidContainer1, liquidContainer2, gasContainer1});
        // Console.WriteLine(ship);

        // Remove container from ship ##################################################################
        // ship.RemoveContainer(liquidContainer1);
        // Console.WriteLine(ship);

        // Unload the container ########################################################################
        // Console.WriteLine(liquidContainer1);
        // liquidContainer1.Unload();
        // Console.WriteLine(liquidContainer1);

        // Console.WriteLine(gasContainer1);
        // gasContainer1.Unload();
        // Console.WriteLine(gasContainer1);

        // Replace container on ship ###################################################################
        // Console.WriteLine(ship);
        // ship.ReplaceContainer(liquidContainer1.SerialNumber, gasContainer1);
        // Console.WriteLine(ship);

        // Move container between two ships ############################################################
        // Console.WriteLine(ship);
        // Console.WriteLine(ship2);
        // ship.MoveContainerBetweenShips(ship2, liquidContainer1.SerialNumber);
        // Console.WriteLine(ship);
        // Console.WriteLine(ship2);
    }
}