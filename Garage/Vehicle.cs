using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Vehicle:IVehicle
    {
        private string _Regnumber;
        private string _Color;
        private int _NbrOFWheels;
        private string _Model;
        private int _NbrOfWindows;

        public Vehicle(string regnumber, string color, int nbrOFWheels, string model, int nbrOfWindows)
        {
            _Regnumber = regnumber;
            _Color = color;
            _NbrOFWheels = nbrOFWheels;
            _Model = model;
            _NbrOfWindows = nbrOfWindows;
        }
        public override string ToString()
        {
            return $"Vehicle Type: {GetType().Name},Regnumber: {Regnumber}, Color: {Color}, Wheels: {NbrOFWheels}, Model: {Model}, Windows: {NbrOfWindows}";
        }

        public string Regnumber { get { return _Regnumber; } set { _Regnumber = Regnumber; } }
        public string Color { get { return _Color; } set { _Color = Color; } }
        public int NbrOFWheels { get { return _NbrOFWheels; } set { _NbrOFWheels = NbrOFWheels; } }
        public string Model { get { return _Model; } set { _Model = Model; } }
        public int NbrOfWindows { get { return _NbrOfWindows; } set { _NbrOfWindows = NbrOfWindows; } }
    }
}
