using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaReservaRestaurant.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CustemerId { get; set; }
        public int TableId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int PartySize { get; set; }
        public string SpecialRequest { get; set; }
        public ReservationStatus Status { get; set; }

        public override string ToString()
        {
            //return $"Date : {Date.ToShortDateString()}, Capacidad: {Capacity}, IsAvailable: {IsAvailable}";
        }
    }
}
