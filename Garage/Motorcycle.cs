using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Motorcycle : Vehicle
    {
        private double _CylinderVolume;
        public Motorcycle(string regnumber, string color, int nbrOFWheels, string model, int nbrOfWindows, double cylinderVolume) : base(regnumber, color, nbrOFWheels, model, nbrOfWindows)
        {
            _CylinderVolume = cylinderVolume;
        }
        public double CylinderVolume { get {return _CylinderVolume; } set { _CylinderVolume = CylinderVolume; } }

        public override string ToString()
        {
            return $"Vehicle Type: {GetType().Name}, Regnumber: {Regnumber}, Color: {Color}, Wheels: {NbrOFWheels}, Model: {Model}, Windows: {NbrOfWindows}, Cylinder Volume: {CylinderVolume}";
        }
    }
}
