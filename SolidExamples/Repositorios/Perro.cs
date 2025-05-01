using SolidExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Repositorios
{
    public class Perro : IAnimal
    {
        public void HacerSonido()
        {
            Console.WriteLine("El perro dice: ¡Guau guau!");
        }
    }
}
