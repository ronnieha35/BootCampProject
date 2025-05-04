using SistemaReservaRestaurant.Models;
using SistemaReservaRestaurant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Services
{
    public class ReservationServices : IReservationServices
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationServices(IReservationRepository reservationRepository)
        {
            this._reservationRepository = reservationRepository;
        }
        public bool CancelReservation(Reservation reservation)
        {
            try
            {
                var existintReservation = _reservationRepository.GetById(reservation.Id);

                if (existintReservation == null)
                {
                    return false;
                }

                existintReservation.Status = ReservationStatus.cancelling;
                _reservationRepository.Update(existintReservation);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
          
        }

        public bool CreateReservation(Reservation reservation)
        {
            try
            {
                //Setear el status
                reservation.Status = ReservationStatus.pending;

                _reservationRepository.Add(reservation);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Reservation> GetByReservationByDate(DateTime date)
        {
            return _reservationRepository.GetReservationByDate(date);
        }

        public Reservation GetReservationById(int id)
        {
            return _reservationRepository.GetById(id);
        }

        public bool UpdateReservation(Reservation reservation)
        {
            try
            {
                _reservationRepository.Update(reservation);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
