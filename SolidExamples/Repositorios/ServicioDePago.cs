using SolidExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExamples.Repositorios
{
    public class ServicioDePago
    {
        private readonly IPasareladePago _pasarela;

        public ServicioDePago(IPasareladePago pasarela)
        {
            _pasarela = pasarela;
        }

        public void RealizarPago(decimal monto)
        {
            _pasarela.ProcesarPago(monto);
        }


    }
}
