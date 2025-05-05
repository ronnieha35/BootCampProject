using SistemaReservaAutos.Models;
using SistemaReservaAutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public List<Payment> GetAllPayment()
        {
            return _paymentRepository.GetAll();
        }

        public List<Payment> GetPaymentsByDate(DateTime paymentDate)
        {
            return _paymentRepository.GetPaymentsByDate(paymentDate);
        }

        public List<Payment> GetPaymentsByReservation(int reservationId)
        {
            return _paymentRepository.GetPaymentsByReservation(reservationId);
        }
    }
}
