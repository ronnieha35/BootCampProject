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
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public bool CreateReservation(Reservation reservation)
        {
            try
            {
                reservation.statusReservation = StatusReservation.Active;

                _reservationRepository.Add(reservation);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool CancelReservation(Reservation reservation)
        {
            var existingReservation = _reservationRepository.GetById(reservation.Id);
            if (existingReservation == null)
                return false;

            existingReservation.statusReservation = StatusReservation.Canceled;
            _reservationRepository.Update(existingReservation);

            return true;
        }

        public Reservation GetReservationById(int id)
        {
            return _reservationRepository.GetById(id);
        }

        public List<Reservation> GetReservationsByDate(DateTime date)
        {
            return _reservationRepository.GetReservationsByDate(date);
        }

        public bool UpdateReservation(Reservation reservation)
        {
            try
            {
                _reservationRepository.Update(reservation);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
