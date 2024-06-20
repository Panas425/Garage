using Garage;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;

namespace TestProject3
{
    public class GarageTests
    {
        private Garage<Vehicle> _garage = new Garage<Vehicle>(5);

        [Fact]
        public void AddVehicle_ShouldAddVehicleToGarage()
        {
            // Arrange

            Vehicle vehicle1 = new Car("ABC123", "Red", 4, "ModelA", 4, "Diesel");
            Vehicle vehicle2 = new Airplane("ABD543", "Blue", 3, "Airbus", 54, 7);

            // Act
            _garage.AddVehicle(vehicle1);
            _garage.AddVehicle(vehicle2);

            // Assert
            Assert.Equal(2, _garage.Count);
            Assert.Equal(vehicle1, _garage.SearchVehicle("ABC123"));
            Assert.Equal(vehicle2, _garage.SearchVehicle("ABD543"));
        }

        [Fact]
        public void AddVehicle_ShouldNotAddDuplicateVehicle()
        {
            // Arrange
            var vehicle = new Vehicle("ABC123", "Red", 4, "ModelX", 4);

            // Act
            _garage.AddVehicle(vehicle);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _garage.AddVehicle(vehicle));
            Assert.Equal(1, _garage.Count);
        }

        [Fact]
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
    }
}