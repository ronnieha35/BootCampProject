using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Repository
{
    public class BillteraRepository : IBilletera
    {
        public void Depositar(Usuario usuario, decimal monto)
        {
            var transaccion = new Transaccion(monto, "Depósito", "Depósito de efectivo");
            usuario.billetera.AgregarTransaccion(transaccion);
            Console.WriteLine($"Depósito realizado. Nuevo saldo: S/ {usuario.billetera.Saldo:N2}");
        }

        public decimal ObtenerSaldo(Usuario usuario)
        {
            return usuario.billetera.Saldo;
        }

        public List<Transaccion> ObtenerTransacciones(Usuario usuario)
        {
            return usuario.billetera.movimientos;
        }

        public void Retirar(Usuario usuario, decimal monto)
        {
            if (usuario.billetera.Saldo < monto)
            {
                Console.WriteLine("Saldo insuficiente.");
                return;
            }

            var transaccion = new Transaccion(monto, "Retiro", "Retiro de efectivo");
            usuario.billetera.AgregarTransaccion(transaccion);
            Console.WriteLine($"Retiro realizado. Nuevo saldo: S/ {usuario.billetera.Saldo:N2}");
        }

        public void Transferir(Usuario origen, Usuario destino, decimal monto)
        {
            if (origen.billetera.Saldo < monto)
            {
                Console.WriteLine("Saldo insuficiente para transferir.");
                return;
            }

            var transSalida = new Transaccion(monto, "Transferencia", $"Transferencia a {destino.Nombre}");
            var transEntrada = new Transaccion(monto, "Depósito", $"Transferencia de {origen.Nombre}");

            origen.billetera.AgregarTransaccion(transSalida);
            destino.billetera.AgregarTransaccion(transEntrada);

            Console.WriteLine($"Transferencia realizada. Nuevo saldo: S/ {origen.billetera.Saldo:N2}");
        }
    }
}
