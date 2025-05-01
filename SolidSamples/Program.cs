using SolidSamples.Clase;
using SolidSamples.Interfaces;

namespace SolidSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SRP");

            IPasarelaPago pasarelaPago = new PagoConPayPal();
            //Console.WriteLine($"pago paypal {pasarelaPago.ProcesarPago(452.23M)}";
        }
    }
}
