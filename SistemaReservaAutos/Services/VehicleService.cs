using SistemaReservaAutos.Models;
using SistemaReservaAutos.Repositories;
using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public bool CreateVehicle(Vehicle vehicle)
        {
            try
            {
                _vehicleRepository.Add(vehicle);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAll();
        }

        public List<Vehicle> GetAvailablesVehicles(StatusVehicle statusVehicle)
        {
            return _vehicleRepository.GetAvailableByStatus(statusVehicle);
        }

        public Vehicle GetByVehicleId(int id)
        {
            return _vehicleRepository.GetById(id);
        }

        public bool UpdateStatusVehicle(Vehicle vehicle)
        {
            try
            {
                _vehicleRepository.Update(vehicle);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
