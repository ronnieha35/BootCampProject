using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Models
{
    public interface ITrabajador
    {
        decimal CalcularComision(decimal sueldo);
    }
}
