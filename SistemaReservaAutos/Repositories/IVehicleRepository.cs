using SistemaReservaAutos.Models;
using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        List<Vehicle> GetAvailableByStatus(StatusVehicle isAvailable);
        List<Vehicle> GetVehiclesByBrand(string brand);
        List<Vehicle> GetAvailableVehicles();
    }
}
