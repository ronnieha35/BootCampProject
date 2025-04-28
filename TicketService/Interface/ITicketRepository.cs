using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Enumeradores;
using TicketService.Models;

namespace TicketService.Interface
{
    public interface ITicketRepository
    {
        public void AddTicket(Ticket ticket);

        public void AddCommentTicket(Comment comment, Ticket ticket);

        public List<Ticket> GetAll();

        public Ticket GetByIdTicket(int id);

        public void DeleteTicket(Ticket ticket);

        public List<Ticket> GetTicketByIdUser(int id);

        public List<Ticket> GetTicketByFecha(DateTime fechainicial, DateTime fechafin);

        public List<Ticket> GetByPriority(Priority priority);
    }
}
