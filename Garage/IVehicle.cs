using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IVehicle
    {
        string Regnumber { get; set; }
        string Color { get; set; }
        int NbrOFWheels { get; set; }
        string Model { get; set; }
        int NbrOfWindows { get; set; }
    }
}
