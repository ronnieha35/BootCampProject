using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Models
{
    public class Gerente : Trabajador
    {
        public Gerente(string nombre, decimal sueldo) : base(nombre, sueldo)
        {
        }

        public override decimal CalcularBonificacion()
        {
            return SueldoBase * 0.20m;
        }
    }
}
