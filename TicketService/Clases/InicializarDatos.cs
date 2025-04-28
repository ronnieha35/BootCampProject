using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Clases;
using TicketService.Enumeradores;
using TicketService.Interface;
using TicketService.Models;
using TicketService.Repository;

namespace TicketService.Clases
{
    public class InicializarDatos
    {
        readonly ITicketRepository _ticketRepository = new TicketRepository();
        readonly IDeveloperRepository _developerRepository = new DeveloperRepository();
        readonly ICommentRepository _commentRepository = new CommentRepository();

        public InicializarDatos(ITicketRepository ticketRepository, IDeveloperRepository developerRepository, ICommentRepository commentRepository)
        {
            _ticketRepository = ticketRepository;
            _developerRepository = developerRepository;
            _commentRepository = commentRepository; 
        }


        public void InicializarDatosPrincipales()
        {
            //Agregamos los Developers
            var developer1 = new Developer()
            {
                Nombre = "Ronnie Alarcon",
                dni = "40801644",
                Role = "Developer",
                Seniority = "Semi Senior",
                edad = "44",
                genero = Genero.Masculino,


            };

            _developerRepository.Add(developer1);

            var developer2 = new Developer()
            {
                Nombre = "Migue Loza",
                dni = "10405565",
                Role = "Developer",
                Seniority = "Semi Senior",
                edad = "54",
                genero = Genero.Masculino,

            };

            _developerRepository.Add(developer2);


            //Agregamos los Tickets

            var ticket1 = new Ticket
            {
                Title = "Cambio de N° de Orden de Compra",
                Description = "Se debe cambiar el N° de Orden a 12455",
                ticketCategory = TicketCategory.Cambio,
                Status = TicketStatus.Pendiente,
                Priority = Priority.Normal,
                ReportedBy = "Ventas",
                CreateDate = DateTime.Now.Date.AddDays(-1)
            };

            _ticketRepository.AddTicket(ticket1);

            var ticket2 = new Ticket
            {

                Title = "Agregar Reporte de Ventas Diarias",
                Description = "Se necesita agregar un reporte de ventas",
                ticketCategory = TicketCategory.Desarrollo,
                Status = TicketStatus.Pendiente,
                Priority = Priority.Alta,
                ReportedBy = "Ventas",
                CreateDate = DateTime.Now.Date.AddDays(-2)

            };

            _ticketRepository.AddTicket(ticket2);

            var ticket3 = new Ticket
            {

                Title = "Error de Conexion a la VPN",
                Description = "No se puede acceder a la VPN",
                ticketCategory = TicketCategory.Incidencia,
                Status = TicketStatus.Pendiente,
                Priority = Priority.Alta,
                ReportedBy = "Ventas",
                CreateDate = DateTime.Now.Date

            };

            _ticketRepository.AddTicket(ticket3);

            //Agregamos 1 comment
            var comment1 = new Comment()
            {
                Author = "Ronnie Alarcon",
                Text = "Desarrollo en proceso",
                CreatedDate = DateTime.Now.Date,
            };

            _commentRepository.AddComment(comment1);
            //Asignamos el comment al Ticket1
            ticket1.comments = new List<Comment>();
            _ticketRepository.AddCommentTicket(comment1, ticket1);


            //Asignamos los Developers a los tickets
            ticket1.Assignedto = developer1;
            ticket2.Assignedto = developer1;
            ticket3.Assignedto = developer2;

            //Asignamos los tickets a los usuarios
            developer1.tickets = new List<Ticket>() { ticket1, ticket2 };
            //developer1.tickets.Add(ticket1);
            //developer1.tickets.Add(ticket2);

            developer2.tickets = new List<Ticket> { ticket3 };
            //developer2.tickets.Add(ticket3);


       
         

        }
    }
}
