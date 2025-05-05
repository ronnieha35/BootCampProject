using SistemaReservaAutos.Repositories;
using SistemaReservaAutos.Services;
using SistemaReservaAutos.UI;
using System.Linq.Expressions;

namespace SistemaReservaAutos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerService = new CustomerService(new CustomerRepository(),new ReservationRepository());
            var vehicleService = new VehicleService(new VehicleRepository());
            var reservationService = new ReservationService(new ReservationRepository());
            var paymentService = new PaymentService(new PaymentRepository());

            //Inicializar Consola UI
            var ui = new ConsoleUI(reservationService, customerService, vehicleService, paymentService);

            ui.Run();
        }
    }
}
