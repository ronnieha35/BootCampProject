using SolidExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Repositorios
{
    public class CalcularRectangulo : ICalcularRepository
    {
        public decimal CalcularValores(decimal valorbase, decimal valoraltura)
        {
            decimal area = valoraltura * valorbase;

            return area;
        }
    }
}
