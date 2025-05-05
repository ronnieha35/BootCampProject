using SistemaReservaAutos.Models;
using SistemaReservaAutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IReservationRepository _reservationRepository;

        public CustomerService(ICustomerRepository customerRepository, IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                _customerRepository.Add(customer);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }
            
        }

        public List<Customer> GetCustomer()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetByEmail(email);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public List<Reservation> GetCustomerReservations(int id)
        {
            throw new NotImplementedException();
        }
    }
}
