using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Repositories
{
    internal class ReservationRepository : IReservationRepository
    {
        private List<Reservation> _reservations = new List<Reservation>();
        private int _nextId = 1;
        public void Add(Reservation entity)
        {
            entity.Id = ++_nextId;
            _reservations.Add(entity);
        }

        public void Delete(Reservation entity)
        {
            _reservations.Remove(entity);
        }

        public List<Reservation> GetAll()
        {
            return _reservations;
        }

        public Reservation? GetById(int id)
        {
            return _reservations.FirstOrDefault(x => x.Id == id);
        }

        public List<Reservation> GetReservationByCustom(int customerID)
        {
            return _reservations.Where(x => x.CustemerId == customerID).ToList();
        }

        public List<Reservation> GetReservationByDate(DateTime date)
        {
            return _reservations.Where(x => x.Date == date).ToList();
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
