using Repaso.Models;

namespace Repaso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trabajador gerente = new Gerente("Ronnie Alarcon", 5000M);
            Trabajador supervisor = new Supervisor("Miguel Loza", 4500M);

            Console.WriteLine($"{gerente.Nombre} bonificación: S/ {gerente.CalcularBonificacion()}");
            Console.WriteLine($"{supervisor.Nombre} bonificación: S/ {supervisor.CalcularBonificacion()}");
        }
    }
}
