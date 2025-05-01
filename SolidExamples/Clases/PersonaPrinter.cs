using SolidExamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Clases
{
    public class PersonaPrinter
    {
        public void Imprimir(Persona persona)
        {
            Console.WriteLine($"Nombre : {persona.Nombre}");
            Console.WriteLine($"Edad : {persona.Edad}");
            Console.WriteLine($"Genero : {persona.Genero}");
        }
    }
}
