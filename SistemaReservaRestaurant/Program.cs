using SistemaReservaRestaurant.Repositories;
using SistemaReservaRestaurant.Services;

namespace SistemaReservaRestaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our DaftDelicias Reservation System");

            //Inicializar el Sistema
            var reservationsServices = new ReservationService(new ReservationRepository());
            var tableService = new TableService(new TableRepository());
            var customerService = new CustomerService(new CustomerRepository());


            //Inicializar nuestra UI (Consola)
            var ui = new ConsoleUI(reservationsServices, tableService, customerService);

            //Inicializar nuestra aplicacion
            ui.Run();
        }
    }
}
