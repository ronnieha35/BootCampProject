using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();
      
        public void SaveUser(Usuario usuario)
        {
            // Verifica si ya existe un usuario con el mismo username
            if (_usuarios.Any(u => u.User == usuario.User))
            {
                Console.WriteLine("El nombre de usuario ya está registrado.");
                return;
            }

            usuario.FechaCreacion = DateTime.Now;
            _usuarios.Add(usuario);
            Console.WriteLine($"Usuario '{usuario.Nombre}' creado con éxito.");
        }

        public List<Usuario> GetAllUsers()
        {
            return _usuarios;
        }

    

        public Usuario? GetbyUser(string user)
        {
            return _usuarios.FirstOrDefault(u => u.User == user);
        }

        public void UpdateUser(Usuario usuario)
        {
            UpdateUser(usuario);
        }

        public Usuario? GetbyIdUsuario(int id)
        {
            return _usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }
    }
}
