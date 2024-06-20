using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Car : Vehicle
    {
        private string _fueltype;
        public Car(string regnumber, string color, int nbrOFWheels, string model, int nbrOfWindows, string fueltype) : base(regnumber, color, nbrOFWheels, model, nbrOfWindows)
        {
            _fueltype = fueltype;
        }
        public string Fueltype { get { return _fueltype; } set {_fueltype= Fueltype; } }
        public override string ToString()
        {
            return $"Vehicle Type: {GetType().Name}, Regnumber: {Regnumber}, Color: {Color}, Wheels: {NbrOFWheels}, Model: {Model}, Windows: {NbrOfWindows}, Fueltype: {Fueltype}";
        }
    }
}
