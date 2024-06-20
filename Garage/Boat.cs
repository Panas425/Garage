namespace Garage
{
    public class Boat : Vehicle
    {
        private double _length;
        public Boat(string regnumber, string color, int nbrOFWheels, string model, int nbrOfWindows, double length) : base(regnumber, color, nbrOFWheels, model, nbrOfWindows)
        {
            _length = length;   
        }
        public double Length { get { return _length; } set { _length = Length; } }
        public override string ToString()
        {
            return $"Vehicle: {GetType().Name}, Regnumber: {Regnumber}, Color: {Color}, Wheels: {NbrOFWheels}, Model: {Model}, Windows: {NbrOfWindows}, Length: {Length}";
        }
    }
}
