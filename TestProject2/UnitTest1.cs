using NUnit.Framework.Constraints;

namespace TestGarage.UnitTests
{
    [TestFixture]
    public class GarageTests
    {
        private Garage<Vehicle> _garage;

        [SetUp]
        public void SetUp()
        {
            // Initialize the garage with a capacity of 5
            _garage = new Garage<Vehicle>(5);
        }

        [Test]
        public void AddVehicle_ShouldAddVehicleToGarage()
        {
            // Arrange
            var vehicle1 = new Vehicle("ABC123", "Red", 4, "ModelX", 4);
            var vehicle2 = new Vehicle("DEF456", "Blue", 2, "ModelY", 2);

            // Act
            _garage.AddVehicle(vehicle1);
            _garage.AddVehicle(vehicle2);

            // Assert
            Assert.AreEqual(2, _garage.Count);
            Assert.AreEqual(vehicle1, _garage.SearchVehicle("ABC123"));
            Assert.AreEqual(vehicle2, _garage.SearchVehicle("DEF456"));
        }

        [Test]
        public void AddVehicle_ShouldNotAddDuplicateVehicle()
        {
            // Arrange
            var vehicle = new Vehicle("ABC123", "Red", 4, "ModelX", 4);

            // Act
            _garage.AddVehicle(vehicle);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _garage.AddVehicle(vehicle));
            Assert.AreEqual(1, _garage.Count);
        }

        [Test]
        public void AddVehicle_ShouldThrowExceptionWhenGarageIsFull()
        {
            // Arrange
            for (int i = 0; i < _garage.Capacity; i++)
            {
                _garage.AddVehicle(new Vehicle($"REG{i}", "Color", 4, "Model", 4));
            }

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _garage.AddVehicle(new Vehicle("NEWREG", "Color", 4, "Model", 4)));
        }


        public class Vehicle : IVehicle
        {
            public string Regnumber { get; set; }
            public string Color { get; set; }
            public int NbrOFWheels { get; set; }
            public string Model { get; set; }
            public int NbrOfWindows { get; set; }

            public Vehicle(string regnumber, string color, int nbrOFWheels, string model, int nbrOfWindows)
            {
                Regnumber = regnumber;
                Color = color;
                NbrOFWheels = nbrOFWheels;
                Model = model;
                NbrOfWindows = nbrOfWindows;
            }
        }

        public interface IVehicle
        {
            string Regnumber { get; set; }
            string Color { get; set; }
            int NbrOFWheels { get; set; }
            string Model { get; set; }
            int NbrOfWindows { get; set; }
        }
    }
}