using SistemaReservaAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        List<Reservation> GetReservationsByCustomer(int customerId);
        List<Reservation> GetActiveReservations();
        List<Reservation> GetReservationsByDate(DateTime date);
    }
}
