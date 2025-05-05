using SistemaReservaAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Services
{
    public interface ICustomerService
    {
        bool CreateCustomer(Customer customer);
        Customer GetCustomerById(int id);
        List<Customer> GetCustomer();
        Customer GetCustomerByEmail(string email);
        List<Reservation> GetCustomerReservations(int id);  
    }
}
