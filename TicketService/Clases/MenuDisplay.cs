using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TicketService.Interface;
using TicketService.Repository;

namespace TicketService.Clases
{
    public class MenuDisplay
    {
        public static void CargarMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================================");
                Console.WriteLine("=== Sistema de Tickets e Incidencias ===");
                Console.WriteLine("========================================\n");
                Console.WriteLine("========== Menu Principal ==========\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Gestion de Developers");
                Console.WriteLine("2. Gestion de Tickets");
                Console.WriteLine("3. Gestion de Comments");
                Console.WriteLine("4. Gestion de Reportes");
                Console.WriteLine("5. Exit\n");
                Console.ResetColor();


                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                Console.ResetColor();

                try
                {
                   
                    switch (opcion)
                    {
                        case "1":
                            GestionDevelopers();
                            break;

                        case "2":
                            GestionTickets();
                            break;

                        case "3":
                            //GestionComments();
                            break;

                        case "4":
                            //GestionReportes();
                            break;

                        case "5":
                            break;

                        default:
                            Console.WriteLine("Opcion Invalida");
                        break;

                    }
                }
                catch (Exception)
                {

                    throw;
                }

                



            }
        }

        #region Region Tickets
        private static void GestionTickets()
        {
            bool retornar = false;

            while (!retornar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=============================");
                Console.WriteLine("=== Gestion de Tickets ===");
                Console.WriteLine("=============================\n");
                Console.WriteLine("1. Crear nuevo Ticket");
                Console.WriteLine("2. Actualizar estado Ticket");
                Console.WriteLine("3. Eliminar Ticket");
                Console.WriteLine("4. Obtener Ticket por Usuario");
                Console.WriteLine("5. Obtener Ticket por Fechas");
                Console.WriteLine("6. Obtener Comentarios por Ticket");
                Console.WriteLine("7. Listar Usuarios/Tickets");
                Console.WriteLine("8. Listar Tickets por Prioridad");
                Console.WriteLine("0. Regresar al menu principal\n");
                Console.ResetColor();

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        TicketFunctions.AddNewTicket();
                        break;
                    case "2":
                        TicketFunctions.UpdateTicket();
                        break;
                    case "3":
                        TicketFunctions.DeleteTicket();
                        break;
                    case "4":
                        TicketFunctions.GetTicketsByUser();
                        break;
                    case "5":
                        TicketFunctions.GetTicketsByDate();
                        break;
                    case "6":
                        TicketFunctions.GetCommentsByTicket();
                        break;
                    case "7":
                        TicketFunctions.GetIdTicketByUsers();
                        break;
                    case "8":
                        TicketFunctions.GetTicketsByPriorid();
                        break;
                    case "0":
                        retornar = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }
            }
        }
        #endregion


        #region Developers
        static void GestionDevelopers()
        {
            bool retornar = false;

           
            while (!retornar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=============================");
                Console.WriteLine("=== Gestion de Developers ===");
                Console.WriteLine("=============================\n");
                Console.WriteLine("1. Crear Developer");
                Console.WriteLine("2. Visualizar Lista Developer");
                Console.WriteLine("0. Regresar al menu principal\n");
                Console.ResetColor();

                Console.WriteLine("Ingrese El Numero de Opcion : ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        DeveloperFunctions.AddNewDevelopers();
                        break;
                    case "2":
                        DeveloperFunctions.ShowListDeveloper();
                        break;
                    case "0":
                        retornar = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }
                Console.ReadKey();
            }
        }

       
        #endregion

      




      
    }
}
