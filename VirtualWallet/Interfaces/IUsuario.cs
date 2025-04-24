using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IUsuario
    {
        void CrearUsuario(Usuario usuario);
        Usuario GetbyUser(string user);
        List<Usuario> GetAllUsers();
    }
}
