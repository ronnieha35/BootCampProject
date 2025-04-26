using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Models
{
    public class Transaccion
    {
        private static int _nextId = 1;

        public int IdTransaccion { get; private set; }
        public int IdUsuario { get;  set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public string Detalle { get; set; }

        public Transaccion() 
        {
            IdTransaccion = _nextId++;
        }

        //public Transaccion(decimal monto, string tipo, string detalle)
        //{
        //    Fecha = DateTime.Now;
        //    Monto = monto;
        //    Tipo = tipo;
        //    Detalle = detalle;
        //}


    }
}
