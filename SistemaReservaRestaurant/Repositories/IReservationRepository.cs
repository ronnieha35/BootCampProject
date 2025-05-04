using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        List<Reservation> GetReservationByDate(DateTime date);
        List<Reservation> GetReservationByCustom(int customerID);
    }
}
