using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public StatusReservation statusReservation { get; set; }

        public override string ToString()
        {
            return $"Reservation: {Id} - Date: {ReservationDate.ToShortDateString()} - ReturnDate: {ReturnDate.ToShortDateString()} - Status: {statusReservation} ";
        }
    }
}
