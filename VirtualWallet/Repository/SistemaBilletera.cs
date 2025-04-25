using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Repository
{
    public class SistemaBilletera
    {
        private readonly IUsuario _usuarioRepository = new UsuarioRepository();

        public void EjecutarCreacionUsuario()
        {
            Console.WriteLine("=== Registro de Nuevo Usuario ===");

            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Correo electrónico: ");
            string correo = Console.ReadLine();

            Console.Write("Nombre de usuario: ");
            string user = Console.ReadLine();

            Console.Write("Clave o PIN: ");
            string clave = Console.ReadLine();

            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                User = user,
                Password = clave
            };

            _usuarioRepository.SaveUser(nuevoUsuario);
        }
    }
}
