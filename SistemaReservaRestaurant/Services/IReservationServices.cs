using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Services
{
    public interface IReservationServices
    {
        bool CreateReservation(Reservation reservation);
        bool UpdateReservation(Reservation reservation);
        bool CancelReservation(Reservation reservation);
        List<Reservation> GetByReservationByDate(DateTime date);
        Reservation GetReservationById(int id);
    }
}
