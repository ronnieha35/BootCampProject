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
