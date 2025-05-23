﻿using SistemaReservaAutos.Models;
using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Services
{
    public interface IVehicleService
    {
        bool CreateVehicle(Vehicle vehicle);
        bool UpdateStatusVehicle(Vehicle vehicle);
        List<Vehicle> GetAvailablesVehicles(StatusVehicle statusVehicle);
        Vehicle GetByVehicleId(int id);
        List<Vehicle> GetAllVehicles();
    }
}
