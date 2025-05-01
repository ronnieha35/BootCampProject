using SolidExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Repositorios
{
    public class CalcularCuadrado : ICalcularRepository
    {
        public decimal CalcularValores(decimal lado1, decimal lado2)
        {
            decimal area = lado1 * lado2;

            return area;
        }
    }
}
