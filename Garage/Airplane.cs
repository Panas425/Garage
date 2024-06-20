using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Airplane : Vehicle
    {
        private int _NbrOfEngines;
        public Airplane(string regnumber, string color, int nbrOFWheels, string model, int nbrOfWindows, int nbrOfEngines) : base(regnumber, color, nbrOFWheels, model, nbrOfWindows)
        {
            _NbrOfEngines = nbrOfEngines;
        }
        public int NbrOfEngines { get { return _NbrOfEngines; } set {_NbrOfEngines = NbrOfEngines; } }
        public override string ToString()
        {
            return $"Vehicle Type: {GetType().Name}, Regnumber: {Regnumber}, Color: {Color}, Wheels: {NbrOFWheels}, Model: {Model}, Windows: {NbrOfWindows}, Number of Engines: {NbrOfEngines}";
        }
    }
}
