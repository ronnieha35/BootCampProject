using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.Interface
{
    public interface ITicketRepository
    {
        public void AddTicket(Ticket ticket);

        public List<Ticket> GetAll();

        public Ticket GetByIdTicket(int id);
    }
}
