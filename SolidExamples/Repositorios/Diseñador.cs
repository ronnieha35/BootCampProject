using SolidExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Repositorios
{
    public class Diseñador : IDiseñador
    {
        public void Diseñar()
        {
            Console.WriteLine("El diseñador crea diseños.");
        }
    }
}
