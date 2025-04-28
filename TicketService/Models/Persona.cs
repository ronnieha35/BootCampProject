using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Enumeradores;

namespace TicketService.Models
{
    public abstract class Persona
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public Genero genero { get; set; }
        public string dni { get; set; }
        public string Direccion {  get; set; }
        public string edad {  get; set; }

        public Persona()
        {
            Id = _nextId++;
        }
    }
}
