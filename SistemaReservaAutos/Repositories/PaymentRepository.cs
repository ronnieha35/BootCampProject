using SistemaReservaAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        List<Payment> _payments = new List<Payment>();
        private int _nextId = 1;
        public List<Payment> Add(Payment entity)
        {
            entity.Id = _nextId++;
            _payments.Add(entity);

            return _payments.ToList();
        }

        public void Delete(Payment entity)
        {
            _payments.Remove(entity);
        }

        public List<Payment> GetAll()
        {
            return _payments;
        }

        public Payment? GetById(int id)
        {
            return _payments.FirstOrDefault(x => x.Id == id);
        }

        public List<Payment> GetPaymentsByDate(DateTime paymentDate)
        {
            return _payments.Where(x => x.paymentDate == paymentDate).ToList(); 
        }

        public List<Payment> GetPaymentsByReservation(int reservationId)
        {
            return _payments.Where(x => x.IdReservation == reservationId).ToList();
        }

        public List<Payment> GetPaymentsByUser(int id)
        {
            return _payments.Where(x => x.IdCustomer == id).ToList();
        }

        public void Update(Payment entity)
        {
            var index = _payments.FindIndex(x => x.Id == entity.Id);

            if (index != -1)
            {
                _payments[index] = entity;
            }
        }
    }
}
