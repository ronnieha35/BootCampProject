using SistemaReservaAutos.Models;
using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        List<Vehicle> _vehicles = new List<Vehicle>();
        private int _nextId = 1;

        public VehicleRepository()
        {
            //Init list vehicles
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Toyota", Model = "Corolla", Year = "2025", Segment = StatusSegment.Medium, Type = TypeCar.Sedan,  Plate = "A8D-548", QuantityPax = 5, statusVehicle = StatusVehicle.Available  });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Toyoya", Model = "Yaris", Year = "2025", Segment = StatusSegment.Medium, Type = TypeCar.Sedan, Plate = "C7D-345", QuantityPax = 5, statusVehicle = StatusVehicle.Available });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Hyundai", Model = "Santa Fe", Year = "2025", Segment = StatusSegment.High, Type = TypeCar.Suv, Plate = "B8P-878", QuantityPax = 7, statusVehicle = StatusVehicle.Available });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Hyundai", Model = "New Elantra", Year = "2025", Segment = StatusSegment.Medium, Type = TypeCar.Sedan, Plate = "A1R-159", QuantityPax = 5, statusVehicle = StatusVehicle.Available });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Geely", Model = "Starray", Year = "2025", Segment = StatusSegment.Medium, Type = TypeCar.Suv, Plate = "D5V-471", QuantityPax = 5, statusVehicle = StatusVehicle.Available });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Audi", Model = "Q5", Year = "2025", Segment = StatusSegment.High, Type = TypeCar.Sedan, Plate = "A9C-764", QuantityPax = 7, statusVehicle = StatusVehicle.Available });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Nissan", Model = "Qasqai", Year = "2025", Segment = StatusSegment.Medium, Type = TypeCar.Suv, Plate = "A2C-199", QuantityPax = 5, statusVehicle = StatusVehicle.Available });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Nissan", Model = "Sentra", Year = "2025", Segment = StatusSegment.Medium, Type = TypeCar.Sedan, Plate = "B1A-795", QuantityPax = 5, statusVehicle = StatusVehicle.Available });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "BMW", Model = "Serie 3", Year = "2025", Segment = StatusSegment.High, Type = TypeCar.Sedan, Plate = "A2B-478", QuantityPax = 5, statusVehicle = StatusVehicle.Available });
            _vehicles.Add(new Vehicle { Id = _nextId++, Brand = "Toyota", Model = "Avanza", Year = "2025", Segment = StatusSegment.Medium, Type = TypeCar.Van, Plate = "B8G-881", QuantityPax = 9, statusVehicle = StatusVehicle.Available });

        }

        public List<Vehicle> Add(Vehicle entity)
        {
            entity.Id = _nextId++;
            _vehicles.Add(entity);

            return _vehicles.ToList();
        }

        public void Delete(Vehicle entity)
        {
            _vehicles.Remove(entity);
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public List<Vehicle> GetAvailableByStatus(StatusVehicle isAvailable)
        {
            return _vehicles.Where(x => x.statusVehicle == isAvailable).ToList();
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            return _vehicles.Where(x => x.statusVehicle == StatusVehicle.Available).ToList();
        }

        public Vehicle? GetById(int id)
        {
            return _vehicles.FirstOrDefault(x => x.Id == id);
        }

        public List<Vehicle> GetVehiclesByBrand(string brand)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle entity)
        {
            var index = _vehicles.FindIndex(x => x.Id == entity.Id);

            if (index != -1)
            {
                _vehicles[index] = entity;
            }
        }
    }
}
