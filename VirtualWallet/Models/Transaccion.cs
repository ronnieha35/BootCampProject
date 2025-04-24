using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Models
{
    public class Transaccion
    {

        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public string Detalle { get; set; }

        public Transaccion(decimal monto, string tipo, string detalle)
        {
            Fecha = DateTime.Now;
            Monto = monto;
            Tipo = tipo;
            Detalle = detalle;
        }


    }
}
