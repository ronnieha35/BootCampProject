using SolidPrinciples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Interface
{
    public interface ICanaMensaje
    {
        void Enviar(Mensaje mensaje);
    }
}
