using SistemaReservaAutos.Models;
using SistemaReservaAutos.Utilities;
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

        public CustomerRepository()
        {
            _customers.Add(new Customer { Id = _nextId++, FullName = "Ronnie Alarcon", genero = Genero.Masculino, IdentityDocument = "40801577", PhoneNumber = "989-455-501", Email = "ronnieha@gmail.com", IsVip = true, IsHandicap = false });
            _customers.Add(new Customer { Id = _nextId++, FullName = "Miguel Loza", genero = Genero.Masculino, IdentityDocument = "10458754", PhoneNumber = "978-475-999", Email = "miguelloza@gmail.com", IsVip = false, IsHandicap = false });
            _customers.Add(new Customer { Id = _nextId++, FullName = "Andres Tapia", genero = Genero.Masculino, IdentityDocument = "45985465", PhoneNumber = "969-022-004", Email = "andrestapia@gmail.com", IsVip = false, IsHandicap = false });
            _customers.Add(new Customer { Id = _nextId++, FullName = "Alexa Alarcon", genero = Genero.Femenino, IdentityDocument = "43578787", PhoneNumber = "999-154-874", Email = "alexaalarcon@gmail.com", IsVip = false, IsHandicap = false });
        }

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
