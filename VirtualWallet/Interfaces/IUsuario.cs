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
        void SaveUser(Usuario usuario);
        void UpdateUser(Usuario usuario);
        Usuario? GetbyUser(string user);
        List<Usuario> GetAllUsers();
        Usuario? GetbyIdUsuario(int id);
    }
}
