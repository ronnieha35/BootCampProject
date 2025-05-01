using SolidExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Repositorios
{
    public class PagoConTarjeta : IPasareladePago
    {
        public void ProcesarPago(decimal monto)
        {
            Console.WriteLine($"Procesando pago de {monto:C} con Tarjeta.");
        }
    }
}
