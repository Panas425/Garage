using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] _vehicles;
        private int _count;

        private int _countAirplane;
        private int _countBoat;
        private int _countBus;
        private int _countCar;
        private int _countMotorcycle;

        public int CountAirplane=>_countAirplane;
        public int CountBoat=>_countBoat;
        public int CountBus=>_countBus;
        public int CountCar=>_countCar;
        public int CountMotorcycle=>_countMotorcycle;
        public int Count => _count;
        public int Capacity => _vehicles.Length;

        public Garage(int capacity)
        {
            _vehicles = new T[capacity];
            _count = 0;
        }


        public string AddVehicle(T vehicle)
        {
            if (_vehicles.Any(v => v != null && v.Regnumber == vehicle.Regnumber))
            {
                throw new InvalidOperationException($"Vehicle with registration number {vehicle.Regnumber} already exists in the garage");
                
            }

            else if (_count == _vehicles.Length)
            {
                throw new InvalidOperationException("Garage is full");
            }

            else
            {
                _vehicles[_count++] = vehicle;
                if (vehicle.GetType().Name == "Car") 
                { 
                    _countCar++;
                }
                else if (vehicle.GetType().Name == "Airplane")
                {
                    _countAirplane++;
                }
                else if (vehicle.GetType().Name == "Bus")
                {
                    _countBus++;
                }
                else if (vehicle.GetType().Name == "Boat")
                {
                    _countBoat++;
                }
                else if (vehicle.GetType().Name == "Motorcycle")
                {
                    _countMotorcycle++;
                }
                return "Vehicle parked in the garage";
            }
        }

        public T SearchVehicle(string regnumber)
        {
            return _vehicles.FirstOrDefault(v => v != null && v.Regnumber == regnumber.ToUpper());
        }

        public string RemoveVehicle(string regnumber)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_vehicles[i].Regnumber == regnumber.ToUpper())
                {
                    for (int j = i; j < _count - 1; j++)
                    {
                        _vehicles[j] = _vehicles[j + 1];
                    }
                    _count--;
                    _vehicles[_count] = null;

                    if (_vehicles[i].GetType().Name == "Car")
                    {
                        _countCar--;
                    }
                    else if (_vehicles[i].GetType().Name == "Airplane")
                    {
                        _countAirplane--;
                    }
                    else if (_vehicles[i].GetType().Name == "Bus")
                    {
                        _countBus--;
                    }
                    else if (_vehicles[i].GetType().Name == "Boat")
                    {
                        _countBoat--;
                    }
                    else if (_vehicles[i].GetType().Name == "Motorcycle")
                    {
                        _countMotorcycle--;
                    }
                    return ($"Vehicle with registration number {regnumber} successfully removed.");
                }
            }
            return ($"Vehicle with registration number {regnumber} not found in the garage.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> SearchVehicles(string color = null, int? wheels = null, string type = null)
        {
            var query = _vehicles.Where(v => v != null);

            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
            }

            if (wheels.HasValue)
            {
                query = query.Where(v => v.NbrOFWheels == wheels.Value);
            }

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(v => v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase));
            }

            return query;
        }

    }
}