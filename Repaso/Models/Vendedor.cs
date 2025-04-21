using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Models
{
    public class Vendedor : Trabajador, ITrabajador
    {
        public Vendedor(string nombre, decimal sueldo) : base(nombre, sueldo)
        {
        }

        public override decimal CalcularBonificacion()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularComision(decimal sueldo)
        {
            
            return sueldo * 0.10M + sueldo;
        }
    }
}
