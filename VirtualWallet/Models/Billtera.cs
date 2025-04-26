using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Models
{
    public class Billtera
    {
        public decimal Saldo { get; private set; }
        public List<Transaccion> movimientos { get; private set; }

        public Billtera()
        {
            Saldo = 0;
            movimientos = new List<Transaccion>();
        }

        public void 
            AgregarTransaccion(Transaccion transaccion)
        {
            if (transaccion.Tipo == "Deposito")
                Saldo += transaccion.Monto;
            else if (transaccion.Tipo == "Retiro" || transaccion.Tipo == "Transferencia")
                Saldo -= transaccion.Monto;

            movimientos.Add(transaccion);
        }
    }
}
