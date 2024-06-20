using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Bus : Vehicle
    {
        private int _nbrOfSeats;
        public Bus(string regnumber, string color, int nbrOFWheels, string model, int nbrOfWindows, int nbrOfSeats) : base(regnumber, color, nbrOFWheels, model, nbrOfWindows)
        {
            _nbrOfSeats = nbrOfSeats;
        }
        public int NbrOfSeats {  get { return _nbrOfSeats; } set { _nbrOfSeats = value; } }
        public override string ToString()
        {
            return $"Vehicle Type: {GetType().Name}, Regnumber: {Regnumber}, Color: {Color}, Wheels: {NbrOFWheels}, Model: {Model}, Windows: {NbrOfWindows}, Number of Seats: {NbrOfSeats}";
        }
    }
}
