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
    }
}
