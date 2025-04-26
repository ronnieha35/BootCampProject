using TicketService.Clase;
using TicketService.Enumeradores;
using TicketService.Interface;
using TicketService.Models;

namespace TicketService
{
    internal class Program
    {
        static IPersonaRepository personaRepository = new PersonaRepository();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Crear Persona\n2. Crear Ticket\n3. Ver Tickets\n0. Salir");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearPersona();
                        break;
                }
            }
        }


        #region Persona
        private static void CrearPersona()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Crear Nuevo Usuario ===\n");
            Console.WriteLine("Presione 'Esc' en cualquier momento para cancelar.\n");
            Console.ResetColor();


            Console.Write("Ingrese nombre de usuario: ");
            string nombres = Console.ReadLine();

            Console.WriteLine("Ingrese su genero con la palabra MASCULINO o FEMENINO");
            Genero genero = (Genero)Convert.ToInt32(Console.ReadLine()); // 1 = Masculino

            Console.Write("Ingrese Dni: ");
            string dni = Console.ReadLine();

            Console.Write("Ingrese Direccion: ");
            string direccion = Console.ReadLine();

            Console.Write("Ingrese Edad: ");
            string edad = Console.ReadLine();

            // Validar si los campos son válidos
            if (string.IsNullOrWhiteSpace(nombres) || genero == 0 || string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(edad))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Todos los campos deben ser completados.");
                Console.ResetColor();
                Console.WriteLine("\nPresione una tecla para regresar al menú...");
                Console.ReadKey();
                return;
            }

            Persona nuevoUsuario = new Persona
            {
                Nombre = nombres,
                genero = genero,
                dni = dni,
                Direccion = direccion,
                edad = edad
            };

            personaRepository.AddPersona(nuevoUsuario);
        }
        #endregion

    }
}
