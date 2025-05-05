using SistemaReservaAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Services
{
    public interface IReservationService
    {
        bool CreateReservation(Reservation reservation);
        bool UpdateReservation(Reservation reservation);   
        bool CancelReservation(Reservation reservation);
        List<Reservation> GetReservationsByDate(DateTime date);
        Reservation GetReservationById(int id);
        List<Reservation> GetAllReservations();
        List<Reservation> GetReservationsByStatus();
    }
}
