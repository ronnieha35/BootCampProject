using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Services
{
    public interface ICustomerService
    {
        Customer GetOrCreateCustomore(string Name, string phone, string email);
        Customer GetCustomerById(int id);
        List<Customer> GetCustomers();
        Customer GetCustomersGetByEmail(string email);
        List<Reservation> GetReservationsByCustomer(int customerId);


    }
}
