using Repaso.Models;

namespace Repaso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gerente = new Gerente("Ronnie Alarcon", 5000M);
            var supervisor = new Supervisor("Miguel Loza", 4500M);

            var vendedor = new Vendedor("Carlos Perez",2500);

            

            Console.WriteLine($"{gerente.Nombre} bonificación: S/ {gerente.CalcularBonificacion()}");
            Console.WriteLine($"{supervisor.Nombre} bonificación: S/ {supervisor.CalcularBonificacion()}");
            Console.WriteLine($"{vendedor.Nombre} Sueldo + Comision: S/ {vendedor.CalcularComision(vendedor.SueldoBase)}");




        }
    }
}
