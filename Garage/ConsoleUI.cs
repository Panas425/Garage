using Garage;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ConsoleUI
    {
        public void DisplayGarage(Vehicle vehicle)
        {

            if (vehicle != null)
            {
                Console.WriteLine(vehicle);

            }

        }
        public int setSize()
        {
            int size;
            size = CheckIntValue("Enter size of garage: ");

            return size;


        }
        public Vehicle ReceiveData()
        {

            string type;
            string color;
            string model;

            Console.Write("Enter registration number: ");
            string regnumber = Console.ReadLine().ToUpper();

            Console.Write("Enter Vehicle type: ");
            type = Console.ReadLine().ToUpper();

            Console.Write("Enter color: ");
            color = Console.ReadLine().ToUpper();

            int nbrOFWheels = CheckIntValue("Enter number of wheels: ");

            Console.Write("Enter model: ");
            model = Console.ReadLine().ToUpper();

            int windows = CheckIntValue("Enter number of windows: ");

            if (type == "MOTORCYCLE")
            {
                double cylinderVolume = CheckDoubleValue("Enter number of cylinders: ");
                return new Motorcycle(regnumber, color, nbrOFWheels, model, windows, cylinderVolume);
            }
            else if (type == "BOAT")
            {
                double length = CheckDoubleValue("Enter length: ");
                return new Boat(regnumber, color, nbrOFWheels, model, windows, length);
            }
            else if (type == "BUS")
            {
                int nbrOfSeats = CheckIntValue("Enter number of seats: ");
                return new Bus(regnumber, color, nbrOFWheels, model, windows, nbrOfSeats);
            }
            else if (type == "CAR")
            {
                Console.Write("Enter fueltype: ");
                string fuel = Console.ReadLine().ToUpper();
                return new Car(regnumber, color, nbrOFWheels, model, windows, fuel);
            }
            else if (type == "AIRPLANE")
            {
                int nbrOfEngines = CheckIntValue("Enter number of engines: ");
                return new Airplane(regnumber, color, nbrOFWheels, model, windows, nbrOfEngines);
            }
            else
            {
                throw new ArgumentException("Wrong type of vehicle");
            }
        }
        public int CheckIntValue(string? msg)
        {
            bool isValidInput = false;
            int checkedData;
            do
            {
                Console.Write(msg);
                string input = Console.ReadLine();
                if (int.TryParse(input, out checkedData))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer");
                }

            } while (!isValidInput);
            return checkedData;
        }
        public double CheckDoubleValue(string? msg)
        {
            bool isValidInput = false;
            double checkedData;
            do
            {
                Console.Write(msg);
                string input = Console.ReadLine();
                if (double.TryParse(input, out checkedData))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer");
                }

            } while (!isValidInput);
            return checkedData;
        }
        public void RemoveVehicle(Garage<Vehicle> garage)
        {
            Console.WriteLine("Type Vehicle to remove from garage: ");
            string? vehicleToBeRemoved = Console.ReadLine();
            Console.WriteLine(garage.RemoveVehicle(vehicleToBeRemoved));
        }
        public void AddVehicleToGarage(Garage<Vehicle> garage)
        {

            Vehicle vehicle = ReceiveData();

            if(vehicle != null)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine(garage.AddVehicle(vehicle));
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }    
        }

        public void DisplayGarageSize(Garage<Vehicle> garage, int countAirplane, int countBoat, int countBus, int countCar, int countMotorcycle)
        {
            Console.WriteLine($"The current capacity of the garage is: {garage.Capacity}");
            Console.WriteLine($"The current number of vehicles in the garage is: {garage.Count}");

            if (countAirplane > 0) { Console.WriteLine($"Total Airplanes: {countAirplane}"); }
            if (countBoat > 0) { Console.WriteLine($"Total Boats: {countBoat}"); }
            if (countBus > 0) { Console.WriteLine($"Total Bus: {countBus}"); }
            if (countCar > 0) { Console.WriteLine($"Total Cars: {countCar}"); }
            if (countMotorcycle > 0) { Console.WriteLine($"Total Motorcycle: {countMotorcycle}"); }
        }

        /*public Vehicle vehicleType(string type, string regnumber, string color, int nbrOfWheels, string model, int nbrOfWindows)
        {


        }*/
        public void FindVehicle(Garage<Vehicle> garage)
        {
            Console.Write("Type the register number of the Vehicle: ");
            string regNumber = Console.ReadLine().ToUpper();
            Vehicle foundVehicle = garage.SearchVehicle(regNumber);
            if (foundVehicle != null)
            {
                Console.WriteLine(foundVehicle);
            }
            else
            {
                Console.WriteLine("Vehicle not found");
            }
        }
        public void SearchVehicle(Garage<Vehicle> garage)
        {
            Console.Write("What are u searching for? ");
            string input = Console.ReadLine().ToUpper();
            string[] words = input.Split(' ');
            string? color = null;
            int? wheels = null;
            string? type = null;
            foreach (string word in words)
            {
                if (word == "BLUE" || word == "RED" || word == "GREEN" || word == "YELLOW" || word == "BLACK" ||
                    word == "WHITE" || word == "PURPLE" || word == "PINK" || word == "ORANGE" || word == "BROWN" ||
                    word == "GRAY")
                {
                    color = word;
                }
                if (word == "WHEELS" || word == "WHEEL")
                {
                    int index = Array.IndexOf(words, "WHEELS");
                    wheels = int.Parse(words[--index]);
                }
                if (word == "BOAT" || word == "CAR" || word == "BUS" || word == "AIRPLANE" || word == "MOTORCYCLE"
                    || word == "BOATS" || word == "CARS" || word == "BUS" || word == "AIRPLANES" || word == "MOTORCYCLES")
                {

                    if (EndsWithS(word))
                    {
                        type = word.Substring(0, word.Length - 1);

                    }
                    else
                    {
                        type = word;
                    }

                }
            }



            var filteredVehicles = garage.SearchVehicles(color, wheels, type);

            if (filteredVehicles != null && filteredVehicles.Any())
            {
                PrintVehicles(filteredVehicles);
            }
            else
            {
                Console.WriteLine("No vehicles match your criteria.");
            }
        }

        private static bool EndsWithS(string input)
        {
            return !string.IsNullOrEmpty(input) && input.EndsWith("s", StringComparison.OrdinalIgnoreCase);
        }
        private void PrintVehicles(IEnumerable<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }



}
