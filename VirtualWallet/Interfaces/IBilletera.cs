using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IBilletera
    {
        void Depositar(Usuario usuario, decimal monto);
        void Retirar(Usuario usuario, decimal monto);
        void Transferir(Usuario origen, Usuario destino, decimal monto);
        List<Transaccion> ObtenerTransacciones(Usuario usuario);
        decimal ObtenerSaldo(Usuario usuario);
    }
}
