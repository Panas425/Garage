using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{

    public class GarageHandler
    {

        private Garage<Vehicle> garage;
        private ConsoleUI uI;

        private int size;


        public GarageHandler()
        {
            uI = new ConsoleUI();
            size = uI.setSize();
            garage = new Garage<Vehicle>(size);
            TestGarageHandler();

        }
        public void AddVehicle()
        {

            uI.AddVehicleToGarage(garage);

        }
        private void TestGarageHandler()
        {

        }
        public void DisplayVehicles()
        {
            foreach (Vehicle vehicle in garage)
            {
                Console.WriteLine(vehicle);
            }
        }
        public void RemoveVehicle()
        {
            uI.RemoveVehicle(garage);
        }

        public void DisplayGarageSize()
        {
            uI.DisplayGarageSize(garage, garage.CountAirplane, garage.CountBoat, garage.CountBus, garage.CountCar, garage.CountMotorcycle);
        }
        public void SearchVehicleByRegNbr()
        {
            uI.FindVehicle(garage);
        }
        public void SearchByProperties()
        {

            uI.SearchVehicle(garage);
        }

    }
}
