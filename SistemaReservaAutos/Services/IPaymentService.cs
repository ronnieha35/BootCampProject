using SistemaReservaAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Services
{
    public interface IPaymentService
    {
        bool CreatePayment(Payment payment);
        void DeletePayment(Payment payment); 
        bool UpdatePayment(Payment payment);
        List<Payment> GetAllPayment();
        List<Payment> GetPaymentByUser(int id);
        List<Payment> GetByReservation(int id);
        
    }
}
