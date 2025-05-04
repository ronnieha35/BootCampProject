using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByPhoneNumber(string phoneNumber);
        Customer CustomerByEmail(string email);
    }
}
