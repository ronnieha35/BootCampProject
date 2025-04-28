using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Enumeradores;

namespace TicketService.Models
{
    public class Ticket
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public Priority Priority { get; set; }
        public TicketCategory ticketCategory { get; set; }
        public List<Comment> comments { get; set; }
        public string ReportedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public Developer? Assignedto { get; set; }

        public Ticket()
        {
            Id = _nextId++;
        }


    }
}
