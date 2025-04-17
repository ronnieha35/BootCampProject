using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Models
{
    public class Supervisor : Trabajador
    {
        public Supervisor(string nombre, decimal sueldo) : base(nombre, sueldo)
        {
        }

        public override decimal CalcularBonificacion()
        {
            return SueldoBase * 0.20m;
        }
    }
}
