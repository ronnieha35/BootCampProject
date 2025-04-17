using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Models
{
    public class Vendedor : ITrabajador
    {
        public string Nombre { get; set; }
        public decimal SueldoBase { get; set; }

        public decimal CalcularComision(decimal sueldo)
        {



            return sueldo * 0.10M + sueldo;
        }
    }
}
