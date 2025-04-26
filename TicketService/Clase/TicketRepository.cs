using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Interface;
using TicketService.Models;

namespace TicketService.Clase
{
    public class TicketRepository : ITicketRepository
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();
        public void AddTicket(Ticket ticket)
        {
            // Verifica si ya existe un ticket con el mismo Id
            if (_tickets.Any(u => u.Id == ticket.Id))
            {
                Console.WriteLine("El Ticket ya está registrado.");
                return;
            }

            ticket.CreateDate = DateTime.Now;
            _tickets.Add(ticket);
            Console.WriteLine($"Ticket N° '{ticket.Id}' creado con éxito.");
        }

        public List<Ticket> GetAll()
        {
            return _tickets;
        }

        public Ticket? GetByIdTicket(int id)
        {
            return _tickets.FirstOrDefault(x => x.Id == id);
        }
    }
}
