// See https://aka.ms/new-console-template for more information
using Garage;

GarageHandler handler = new GarageHandler();
bool exit = false;

while (!exit)
{
    Console.WriteLine();
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Add a vehicle");
    Console.WriteLine("2. Display all vehicles");
    Console.WriteLine("3. Display garage size");
    Console.WriteLine("4. Remove Vehicle");
    Console.WriteLine("5. Search Vehicle by Register number");
    Console.WriteLine("6. Search Vehicle by color, vehicle type or number of wheels");
    Console.WriteLine("7. Exit");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine();
            handler.AddVehicle();
            break;
        case "2":
            Console.WriteLine();
            handler.DisplayVehicles();
            break;
        case "3":
            Console.WriteLine();
            handler.DisplayGarageSize();
            break;
        case "4":
            Console.WriteLine();
            handler.RemoveVehicle();
            break;
        case "5":
            Console.WriteLine();
            handler.SearchVehicleByRegNbr();
            break;
        case "6":
            Console.WriteLine();
            handler.SearchByProperties();
            break;
        case "7":
            exit = true;
            break;
        default:
            Console.WriteLine();
            Console.WriteLine("Invalid option. Please choose 1, 2, 3, 4, 5, 6 or 7");
            break;
    }
}
