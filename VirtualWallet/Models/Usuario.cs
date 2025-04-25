using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Models
{
    public class Usuario
    {
        private static int _nextId = 1;

        public int IdUsuario { get; private set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public Billtera billetera { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Usuario()
        {
            IdUsuario = _nextId++;
            billetera = new Billtera();
        }
    }
}
