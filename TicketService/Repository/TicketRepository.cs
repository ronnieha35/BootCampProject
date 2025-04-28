using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Enumeradores;
using TicketService.Interface;
using TicketService.Models;

namespace TicketService.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();
        private readonly List<Comment> _comments = new List<Comment>();

        public void AddCommentTicket(Comment comment, Ticket ticket)
        {
           
            if (_tickets.Any(u => u.Id == ticket.Id))
            {
                ticket.comments.Add(comment);
                Console.WriteLine($"Ticket N° '{ticket.Id}' Comentario Agregado con éxito.");
            }

        }

        public void AddTicket(Ticket ticket)
        {
            // Verifica si ya existe un ticket con el mismo Id
            if (_tickets.Any(u => u.Id == ticket.Id))
            {
                Console.WriteLine("El Ticket ya está registrado.");
                return;
            }

            //ticket.CreateDate = DateTime.Now;
            _tickets.Add(ticket);
            Console.WriteLine($"Ticket N° '{ticket.Id}' creado con éxito.");
        }

        public void DeleteTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                string numTicket = ticket.Id.ToString();
                _tickets.Remove(ticket);
                Console.WriteLine($"Ticket N° '{numTicket}' eliminado.");
            }
        }

        public List<Ticket> GetAll()
        {
            return _tickets;
        }

        public Ticket? GetByIdTicket(int id)
        {
            return _tickets.FirstOrDefault(x => x.Id == id);
        }

        public List<Ticket> GetByPriority(Priority priority)
        {
            return _tickets.Where(x => x.Priority.Equals(priority)).ToList();
        }

        public List<Ticket> GetTicketByFecha(DateTime fechainicial, DateTime fechafin)
        {
            return _tickets.Where(x => x.CreateDate >= fechainicial && x.CreateDate <= fechafin).ToList();
        }

        public List<Ticket> GetTicketByIdUser(int id)
        {
            return _tickets.FindAll(x => x.Assignedto?.Id == id);
        }

    }
}
