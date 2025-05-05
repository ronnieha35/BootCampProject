using SistemaReservaAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        List<Payment> GetPaymentsByReservation(int reservationId);
        List<Payment> GetPaymentsByDate(DateTime paymentDate);
        List<Payment> GetPaymentsByUser(int id);

    }
}
