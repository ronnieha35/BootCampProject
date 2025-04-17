using Repaso.Models;

namespace Repaso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gerente = new Gerente("Ronnie Alarcon", 5000M);
            var supervisor = new Supervisor("Miguel Loza", 4500M);

            var vendedor = new Vendedor();

            

            Console.WriteLine($"{gerente.Nombre} bonificación: S/ {gerente.CalcularBonificacion()}");
            Console.WriteLine($"{supervisor.Nombre} bonificación: S/ {supervisor.CalcularBonificacion()}");
            Console.WriteLine($"Comision {vendedor.CalcularComision(2500M)}");




        }
    }
}
