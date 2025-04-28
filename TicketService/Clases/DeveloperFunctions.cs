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
   
    public class DeveloperFunctions
    {
        private static  IDeveloperRepository _developerRepository = new DeveloperRepository();

        public static void ConfigureDevelopers(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        public static void AddNewDevelopers()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Crear Nuevo Developer ===\n");
            Console.WriteLine("Presione 'Esc' en cualquier momento para cancelar.\n");
            Console.ResetColor();

            string nombres = "";
            string dni = "";
            string rol = "";
            string seniority = "";
            string edad = "";

            Console.Write("Ingrese nombre del Developer: ");
            nombres = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombres))
            {
                Console.WriteLine("Nombre no puede estar vacio. Cancelando...");
                return;
            }


            Console.Write("Ingrese DNI del Developer: ");
            dni = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(dni))
            {
                Console.WriteLine("DNI no puede estar vacio. Cancelando...");
                return;
            }

            Console.Write("Ingrese Rol del Developer: ");
            rol = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(rol))
            {
                Console.WriteLine("Rol no puede estar vacio. Cancelando...");
                return;
            }

            Console.Write("Ingrese Señority del Developero: (Junior - Senior)");
            seniority = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(seniority))
            {
                Console.WriteLine("Seniority no puede estar vacio. Cancelando...");
                return;
            }

            Console.Write("Ingrese la Edad del Developer: ");
            edad = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(edad))
            {
                Console.WriteLine("Edad no puede estar vacio. Cancelando...");
                return;
            }

            var genero = SeleccionarGenero();

            if (!genero.HasValue)
            {
                Console.WriteLine("No se selecciono genero. Cancelando...");
                return;
            }

            // Confirmar grabación
            Console.WriteLine("\n¿Desea guardar este Developer? (S = Sí / cualquier otra tecla para cancelar)");
            var confirmacion = Console.ReadKey(true);


            if (confirmacion.Key == ConsoleKey.S)
            {
                var developer = new Developer()
                {
                    Nombre = nombres,
                    dni = dni,
                    Role = rol,
                    Seniority = seniority,
                    edad = edad,
                    genero = genero.Value,
                };

                _developerRepository.Add(developer);
                Console.WriteLine($"Developer: {developer.Nombre} generado con el ID: {developer.Id} ");
            }
            else
            {
                Console.WriteLine("Operación cancelada. No se guardó el Developer.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static Genero? SeleccionarGenero()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione un Genero:");
            Console.ResetColor();

            int i = 1;
            foreach (Genero gen in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"[{i}] {gen}");
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
                    opcion > 0 && opcion <= Enum.GetValues(typeof(Genero)).Length)
                {
                    return (Genero)(opcion - 1);
                }

                Console.WriteLine(" Opcion invalida.");
            }
        }

        public static void ShowListDeveloper()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.WriteLine($"=== Developers ===");
            Console.WriteLine("=====================================\n");
            Console.ResetColor();


            var developers = _developerRepository.GetAll();

          

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ID".PadRight(5) + "Nombre".PadRight(20) + "dni".PadRight(10) + "Genero".PadRight(15) + "Role".PadRight(15) + "Señority".PadRight(15));
            Console.WriteLine("  " + new string('-', 90));

            foreach (var dev in developers)
            {
                Console.WriteLine(
                   $"{dev.Id.ToString().PadRight(5)}" +
                   $"{dev.Nombre.PadRight(20)}" +
                   $"{dev.dni.PadRight(10)}" +
                   $"{dev.genero.ToString().PadRight(15)}" +
                   $"{dev.Role.ToString().PadRight(15)}" +
                   $"{dev.Seniority.ToString().PadRight(15)}"
                );
            }

            
        }
    }
}
