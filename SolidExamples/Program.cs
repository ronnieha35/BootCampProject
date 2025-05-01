using SolidExamples.Clases;
using SolidExamples.Interfaces;
using SolidExamples.Models;
using SolidExamples.Repositorios;
using System;

namespace SolidExamples
{
    internal class Program
    {
        static readonly ICalcularRepository _calcularCuadrado = new CalcularCuadrado();
        static readonly ICalcularRepository _calcularRectangulo = new CalcularRectangulo();
        static void Main(string[] args)
        {
            
            //Aplicando SRP
            Console.WriteLine("Aplicando SRP");
            Persona persona = new Persona("Ronnie Alarcon",35,"Masculino");
            PersonaPrinter printer = new PersonaPrinter();
            printer.Imprimir(persona);

            Console.ReadKey();

            Console.WriteLine("\n");

            //Aplicando OCP
            Console.WriteLine("Aplicando OCP");
            Console.Write("Ingresar Valor 1 : ");
            decimal valor1 = decimal.Parse(Console.ReadLine());
            Console.Write("Ingresar Valor 2 : ");
            decimal valor2= decimal.Parse(Console.ReadLine());

            Console.WriteLine($"Calcular Area Cuadrado {_calcularCuadrado.CalcularValores(valor1, valor2)}");
            Console.WriteLine($"Calcular Area Rectangulo {_calcularRectangulo.CalcularValores(valor1, valor2)}");

            Console.ReadKey();

            Console.WriteLine("\n");

            //Aplicando LSP
            Console.WriteLine("Aplicando LSP");
            IAnimal miAnimal = new Perro();
            miAnimal.HacerSonido();

            miAnimal = new Gato();
            miAnimal.HacerSonido();

            Console.ReadKey();

            Console.WriteLine("\n");


            Console.WriteLine("Aplicando ISP");
            IProgramador programador = new Programador();
            programador.Programar();

            IDiseñador diseñador = new Diseñador();
            diseñador.Diseñar();

            Console.ReadKey();
            Console.WriteLine("\n");


            Console.WriteLine("Aplicando DIP");
            // Crear la instancia de la implementación concreta
            IPasareladePago pasarela = new PagoConTarjeta();

            // Pasar la implementación a la clase ServicioDePago
            ServicioDePago servicio = new ServicioDePago(pasarela);

            // Realizar el pago
            servicio.RealizarPago(150.75m);
            Console.ReadKey();

            Console.WriteLine("\n");







        }
    }
}
