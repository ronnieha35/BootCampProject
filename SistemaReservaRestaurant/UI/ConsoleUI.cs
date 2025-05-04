using SistemaReservaRestaurant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.UI
{
    public class ConsoleUI
    {
        public readonly IReservationServices _reservationServices;
        public readonly ICustomerService _customerService;
        public readonly ITableService _tableServices;
        private bool _isRunning = true;

        public ConsoleUI(IReservationServices reservationServices, ICustomerService customerService, ITableService tableServices)
        {
            _reservationServices = reservationServices;
            _customerService = customerService;
            _tableServices = tableServices;
        }
    }
}
