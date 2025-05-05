using SistemaReservaAutos.Models;
using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        List<Reservation> _reservations = new List<Reservation>();
        private int _nextId = 1;
        public List<Reservation> Add(Reservation entity)
        {
            entity.Id = _nextId++;
            _reservations.Add(entity);

            return _reservations;
        }

        public void Delete(Reservation entity)
        {
            _reservations.Remove(entity);
        }

        public List<Reservation> GetActiveReservations()
        {
            return _reservations.Where(x => x.statusReservation == StatusReservation.Active).ToList();
        }

        public List<Reservation> GetAll()
        {
            return _reservations;
        }

        public Reservation? GetById(int id)
        {
            return _reservations.Find(x => x.Id == id);
        }

        public List<Reservation> GetReservationsByCustomer(int customerId)
        {
            return _reservations.Where(x => x.CustomerId == customerId).ToList();
        }

        public List<Reservation> GetReservationsByDate(DateTime date)
        {
            return _reservations.Where(x => x.ReservationDate == date).ToList();
        }

        public void Update(Reservation entity)
        {
            var index = _reservations.FindIndex(x => x.Id == entity.Id);

            if (index != -1)
            {
                _reservations[index] = entity;
            }
        }
    }
}
