using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool IsVip { get; set; }
        public bool IsHandicap { get; set; }
        public List<Reservation>? reservationsHistory { get; set; } = new List<Reservation>();

        public override string ToString()
        {
            return $"Customer: {FullName}, Phone: {PhoneNumber}, Vip: {IsVip}, Handicap {IsHandicap}";
        }
    }
}
