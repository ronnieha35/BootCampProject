using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Models
{
    public abstract class Trabajador
    {
        public string Nombre { get; set; }
        public decimal SueldoBase { get; set; }

        public Trabajador(string nombre, decimal sueldo)
        {
            Nombre = nombre;
            SueldoBase = sueldo;
        }

        public abstract decimal CalcularBonificacion();
    }
}
