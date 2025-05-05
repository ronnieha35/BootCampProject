using SistemaReservaAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
        Customer GetByPhoneNumber(string phoneNumber);
    }
}
