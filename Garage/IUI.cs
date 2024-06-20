using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IUI
    {
        void DisplayGarage(Vehicle vehicle);
        int setSize();
        Vehicle ReceiveData();
        int CheckIntValue(string? msg);
        double CheckDoubleValue(string? msg);
        void RemoveVehicle(Garage<Vehicle> garage);
        void AddVehicleToGarage(Garage<Vehicle> garage);
        void DisplayGarageSize(Garage<Vehicle> garage, int countAirplane, int countBoat, int countBus, int countCar, int countMotorcycle);
        void FindVehicle(Garage<Vehicle> garage);
        void SearchVehicle(Garage<Vehicle> garage);
    }
}
