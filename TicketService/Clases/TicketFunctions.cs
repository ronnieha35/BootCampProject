using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Enumeradores;
using TicketService.Interface;
using TicketService.Models;
using TicketService.Repository;

namespace TicketService.Clases
{
    public class TicketFunctions
    {
        private static ITicketRepository _ticketRepository = new TicketRepository();
        private static IDeveloperRepository _developerRepository = new DeveloperRepository();

        public static void ConfigureTicket(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public static void ConfigureDevelopers(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public static void AddNewTicket()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Crear Nuevo Ticket ===\n");
            Console.WriteLine("Presione 'Esc' en cualquier momento para cancelar.\n");
            Console.ResetColor();

            Console.WriteLine("Asunto del Ticket: ");
            string asunto = Console.ReadLine();

            Console.WriteLine("Descripcion del Ticket: ");
            string descripcion = Console.ReadLine();

            Console.WriteLine("Status: ");
            var status = SeleccionarStatus();

            Console.WriteLine("Prioridad: ");
            var priority = SeleccionarPriority();

            Console.WriteLine("Categoria: ");
            var categoria = SeleccionarTicketCategory();

            Console.WriteLine("Reportador por: ");
            string reportadoPor = Console.ReadLine();

            Console.WriteLine("Generado Por: ");
            Developer generadoPor = SeleccionarDeveloper();

            // Confirmar grabación
            Console.WriteLine("\n¿Desea guardar este Ticket? (S = Sí / cualquier otra tecla para cancelar)");
            var confirmacion = Console.ReadKey(true);

            if (confirmacion.Key == ConsoleKey.S)
            {
                var ticket = new Ticket
                {
                    Title = asunto,
                    Description = descripcion,
                    Status = status.Value,
                    Priority = priority.Value,
                    ticketCategory = categoria.Value,
                    ReportedBy = reportadoPor,
                    Assignedto = generadoPor,
                };

                _ticketRepository.AddTicket(ticket);
                Console.ReadKey();
                Console.WriteLine("Presione cualquier tecla para continuar.");
            }
            else
            {
                Console.WriteLine("Operación cancelada. No se guardó el Developer.");
            }
        }

       
        public static void UpdateTicket()
        {
            var ticket = SeleccionarTickets();

            if (ticket == null)
            {
                Console.WriteLine("No hay Tickets disponibles.");
                return;
            }
            var status = SeleccionarStatus();

            if (status == null)
            {
                return;
            }

            Console.WriteLine($"\n¿Desea cambiar el status del Ticket N° {ticket.Id} a {status.Value} (S = Sí / Cualquier otra tecla para cancelar)");
            var confirmacion = Console.ReadKey(true);

            if (confirmacion.Key == ConsoleKey.S)
            {
                ticket.Status = status.Value;
                Console.WriteLine($"Ticket N° {ticket.Id} Modificado correctamente a status {status.Value}");
                Console.ReadKey();
                Console.WriteLine("Presione cualquier tecla para continuar");
            }
            else
            {
                Console.WriteLine("Operación cancelada. No se guardó el Developer.");
            }


        }

        public static void DeleteTicket()
        {
            var ticket = SeleccionarTickets();

            if (ticket == null)
            {
                Console.WriteLine("No hay Tickets disponibles.");
                return;
            }

            _ticketRepository.DeleteTicket(ticket);
        }

        public static void GetTicketsByUser()
        {
            var developers = SeleccionarDeveloper();

            if (developers == null)
            {
                Console.WriteLine("No hay developers disponibles.");
                return;
            }

            var _develop = _developerRepository.GetById(developers.Id);
            var ticketsByDevelop = _ticketRepository.GetTicketByIdUser(_develop.Id);

            if (ticketsByDevelop.Count > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.WriteLine($"===  Tickets By Developers ===");
                Console.WriteLine("=====================================\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("ID".PadRight(5) + "Assignedto".PadRight(25) + "Priority".PadRight(15) + "Status".PadRight(15));
                Console.WriteLine("  " + new string('-', 90));

                foreach (var ticket in ticketsByDevelop)
                {
                    Console.WriteLine($"{ticket.Id.ToString().PadRight(5)}" +
                                      $"{ticket.Assignedto.Nombre.ToString().PadRight(25)}" +
                                      $"{ticket.Priority.ToString().PadRight(15)}" +
                                      $"{ticket.Status.ToString().PadRight(15)}"
                                      );

                }
                Console.ReadKey();
                Console.WriteLine("Presione Cualquier Tecla Para continuar");
            } 
        }

        public static void GetTicketsByDate()
        {
            DateTime fechainicio;
            DateTime fechafin;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Ingrese la fecha inicial (dd/MM/yyyy): ");
                Console.ResetColor();
                string entradaInicio = Console.ReadLine()?.Trim();

                if (!DateTime.TryParseExact(entradaInicio, "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out fechainicio))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fecha inicial inválida. Use el formato dd/MM/yyyy.\n");
                    Console.ResetColor();
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Ingrese la fecha final (dd/MM/yyyy): ");
                Console.ResetColor();
                string entradaFin = Console.ReadLine()?.Trim();

                if (!DateTime.TryParseExact(entradaFin, "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out fechafin))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fecha final inválida. Use el formato dd/MM/yyyy.\n");
                    Console.ResetColor();
                    continue;
                }

                if (fechainicio > fechafin)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La fecha inicial no puede ser mayor que la fecha final.\n");
                    Console.ResetColor();
                    continue;
                }

                break; // Ambas fechas están OK
            }

            var tickets = _ticketRepository.GetTicketByFecha(fechainicio, fechafin);

            if (tickets.Count == 0)
            {
                Console.WriteLine("No hay Tickets disponibles.");
                return;
            }

            MostrarTickets(tickets);
           

            Console.ReadKey();
           
            Console.WriteLine("Presione Cualquier Tecla para continuar");

        }

        public static void GetCommentsByTicket()
        {

        }

        public static void GetIdTicketByUsers()
        {
            var developers = _developerRepository.GetAll();


            if (developers.Count == 0)
            {
                Console.WriteLine("No hay Ticket por mostrar");
                return;
            }

            MostrarDevelopers(developers);
            Console.ReadKey();
            Console.WriteLine("Presione cualquier tecla para continuar");


        }

        public static void GetTicketsByPriorid()
        {
            var prioridad = SeleccionarPriority();

            List<Ticket> tickets = _ticketRepository.GetByPriority(prioridad.Value);

            MostrarTickets(tickets);

            Console.ReadKey();
            Console.WriteLine("Presione Cualquier Tecla para continuar");



        }

        static TicketCategory? SeleccionarTicketCategory()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione una Categoria:");
            Console.ResetColor();

            int i = 1;
            foreach (TicketCategory category in Enum.GetValues(typeof(TicketCategory)))
            {
                Console.WriteLine($"[{i}] {category}");
                i++;
            }
            Console.WriteLine("[0] Cancelar");

            while (true)
            {
                Console.Write("Opción: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return null;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= Enum.GetValues(typeof(TicketCategory)).Length)
                {
                    return (TicketCategory)(opcion - 1);
                }

                Console.WriteLine(" Opcion invalida.");
            }
        }

        static Priority? SeleccionarPriority()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione una Prioridad:");
            Console.ResetColor();

            int i = 1;
            foreach (Priority priority in Enum.GetValues(typeof(Priority)))
            {
                Console.WriteLine($"[{i}] {priority}");
                i++;
            }
            Console.WriteLine("[0] Cancelar");

            while (true)
            {
                Console.Write("Opción: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return null;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= Enum.GetValues(typeof(Priority)).Length)
                {
                    return (Priority)(opcion - 1);
                }

                Console.WriteLine(" Opcion invalida.");
            }
        }

        static TicketStatus? SeleccionarStatus()
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione un Status:");
            Console.ResetColor();

            int i = 1;
            foreach (TicketStatus status in Enum.GetValues(typeof(TicketStatus)))
            {
                Console.WriteLine($"[{i}] {status}");
                i++;
            }
            Console.WriteLine("[0] Cancelar");

            while (true)
            {
                Console.Write("Opción: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return null;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= Enum.GetValues(typeof(TicketStatus)).Length)
                {
                    return (TicketStatus)(opcion - 1);
                }

                Console.WriteLine(" Opcion invalida.");
            }
        }

        static Developer SeleccionarDeveloper()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Seleccione un Developer:");
            Console.ResetColor();

            var developers = _developerRepository.GetAll();

            if (developers.Count == 0)
            {
                Console.WriteLine("No hay developers disponibles.");
                return null;
            }

        

            int i = 1;
            foreach (var develop in developers)
            {
                Console.WriteLine($"[{i}] Id: {develop.Id} Nombre: {develop.Nombre}");
                i++;
            }
            Console.WriteLine("[0] Cancelar");

            while (true)
            {
                Console.Write("Opción: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return null;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <=  developers.Count)
                {

                    return developers[opcion - 1];
                }

                Console.WriteLine(" Opcion invalida.");
            }

        }

        static Ticket SeleccionarTickets()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Seleccione un Ticket:");
            Console.ResetColor();

            var tickets = _ticketRepository.GetAll();

            if (tickets.Count == 0)
            {
                Console.WriteLine("No hay developers disponibles.");
                return null;
            }

            int i = 1;
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"[{i}] Id: {ticket.Id} Nombre: {ticket.Description} Creado por: {ticket.Assignedto} Status: {ticket.Status}");
                i++;
            }

            Console.WriteLine("[0] Cancelar");

            while (true)
            {
                Console.Write("Opción: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return null;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= tickets.Count)
                {

                    return tickets[opcion - 1];
                }

                Console.WriteLine(" Opcion invalida.");
            }
        }

        static List<Ticket> MostrarTickets(List<Ticket> tickets)
        {
            if (tickets.Count > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.WriteLine($"===  Tickets By Developers ===");
                Console.WriteLine("=====================================\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("ID".PadRight(5) + "Assignedto".PadRight(25) + "Priority".PadRight(15) + "Status".PadRight(15));
                Console.WriteLine("  " + new string('-', 90));

                foreach (var ticket in tickets)
                {
                    Console.WriteLine($"{ticket.Id.ToString().PadRight(5)}" +
                                      $"{ticket.Assignedto.Nombre.ToString().PadRight(25)}" +
                                      $"{ticket.Priority.ToString().PadRight(15)}" +
                                      $"{ticket.Status.ToString().PadRight(15)}"
                                      );

                }
               
            }

            return tickets;
        }

        static void MostrarDevelopers(List<Developer> developers)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.WriteLine($"===  Developers with Tickets ===");
            Console.WriteLine("=====================================\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("IdTicket".PadRight(10) + "Nombre".PadRight(25) + "Seniority".PadRight(15) + "Role".PadRight(15) + "Dni".PadRight(10));
            Console.WriteLine("  " + new string('-', 90));

            foreach (Developer developer in developers)
            {
                if (developer.tickets.Count > 0)
                {
                   
                    foreach (var ticket in developer.tickets)
                    {
                        
                        Console.WriteLine($"{ticket.Id.ToString().PadRight(10)}" +
                                          //$"{ticket.Title.ToString().PadRight(45)}" +
                                          $"{developer.Nombre.ToString().PadRight(25)}" +
                                          $"{developer.Seniority.ToString().PadRight(15)}" +
                                          $"{developer.Role.ToString().PadRight(15)}" +
                                          $"{developer.dni.PadRight(10)}"
                                          );

                    }

                }
            }
            
            

         
        }
    }
}
