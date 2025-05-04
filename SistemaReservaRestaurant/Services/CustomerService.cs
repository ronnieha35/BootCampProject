using SistemaReservaRestaurant.Models;
using SistemaReservaRestaurant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IReservationRepository _reservationRepository;

        public CustomerService(ICustomerRepository customerRepository, IReservationRepository reservationRepository)
        {
            this._customerRepository = customerRepository;
            this._reservationRepository = reservationRepository;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomersGetByEmail(string email)
        {
            return _customerRepository.CustomerByEmail(email);
        }

        public Customer GetOrCreateCustomore(string Name, string phone, string email)
        {
            var customer = _customerRepository.CustomerByEmail(email);

            if (customer != null)
                return customer;
        }

        public List<Reservation> GetReservationsByCustomer(int customerId)
        {
            return _reservationRepository.GetReservationByCustom(customerId);
        }

     
    }
}
