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

        public bool CreatePayment(Payment payment)
        {
            try
            {
                _paymentRepository.Add(payment);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }
        }

        public List<Payment> GetAllPayment()
        {
            return _paymentRepository.GetAll();
        }

        public List<Payment> GetPaymentByUser(int id)
        {
            return _paymentRepository.GetPaymentsByUser(id);
        }
    }
}
