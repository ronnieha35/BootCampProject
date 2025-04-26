using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketService.Interface;
using TicketService.Models;

namespace TicketService.Clase
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly List<Persona> _personas = new List<Persona>();
        public void AddPersona(Persona persona)
        {
            // Verifica si ya existe un Usuario con el mismo Id
            if (_personas.Any(u => u.Id == persona.Id))
            {
                Console.WriteLine("El Usuario ya está registrado.");
                return;
            }

            
            _personas.Add(persona);
            Console.WriteLine($"Usuario '{persona.Nombre}' creado con éxito.");
        }

        public List<Persona> GetAll()
        {
            return _personas;
        }

        public Persona? GetByIdPersona(int id)
        {
            return _personas.FirstOrDefault(u => u.Id == id);
        }
    }
}
