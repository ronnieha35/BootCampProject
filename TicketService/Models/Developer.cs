using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Models
{
    public class Developer
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Role { get; set; }
        public string Seniority { get; set; }
        public List<Ticket> tickets { get; set; }

        public Developer()
        {
            Id = _nextId++;
        }
    }
}
