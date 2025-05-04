using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();
        private int _nextId = 1;

        public void Add(Customer entity)
        {
            entity.Id = ++_nextId;

            _customerList.Add(entity);
        }

        public Customer? CustomerByEmail(string email)
        {


            return _customerList.Find(x => x.Email == email);
        }

        public void Delete(Customer entity)
        {
            _customerList.Remove(entity);
        }

        public List<Customer> GetAll()
        {
            return _customerList;
        }

        public Customer? GetById(int id)
        {
            return _customerList.FirstOrDefault(x => x.Id == id);
        }

        public Customer? GetByPhoneNumber(string phoneNumber)
        {
            return _customerList.Find(x => x.PhoneNumber == phoneNumber);
        }

        public void Update(Customer entity)
        {
            var index = _customerList.FindIndex(x => x.Id == entity.Id);

            if (index != -1)
            {
                _customerList[index] = entity;
            }

        }
    }
}
