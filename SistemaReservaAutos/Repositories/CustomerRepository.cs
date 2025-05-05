using SistemaReservaAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers = new List<Customer>();
        private int _nextId = 1;

        public List<Customer> Add(Customer entity)
        {
            entity.Id = _nextId++;
            _customers.Add(entity);

            return _customers.ToList();
        }

        public void Delete(Customer entity)
        {
            _customers.Remove(entity);
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer? GetByEmail(string email)
        {
            
            return _customers.FirstOrDefault(x => x.Email == email);
        }

        public Customer? GetById(int id)
        {
            return _customers.FirstOrDefault(x => x.Id == id);
        }

        public Customer? GetByPhoneNumber(string phoneNumber)
        {
            return _customers.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
        }

        public void Update(Customer entity)
        {
            var index = _customers.FindIndex(x => x.Id == entity.Id);

            if (index != -1)
            {
                _customers[index] = entity;
            }
        }
    }
}
