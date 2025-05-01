using SolidSamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidSamples.Clase
{
    public class PagoConTarjeta : IPasarelaPago
    {
        public void ProcesarPago(decimal monto)
        {
            Console.WriteLine($"Procesando pago de {monto:C} con tarjeta de crédito.");
        }
    }
}
