using SolidExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Repositorios
{
    public class Programador : IProgramador
    {
        public void Programar()
        {
            Console.WriteLine("El programador escribe código.");
        }
    }
}
