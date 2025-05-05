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
        List<Payment> GetPaymentsByReservation(int reservationId);
        List<Payment> GetPaymentsByDate(DateTime paymentDate);
        List<Payment> GetAllPayment();
    }
}
