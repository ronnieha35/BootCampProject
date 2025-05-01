using SolidExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Repositorios
{
    public class Gato : IAnimal
    {
        public void HacerSonido()
        {
            Console.WriteLine("El gato dice: ¡Miau!");
        }
    }
}
