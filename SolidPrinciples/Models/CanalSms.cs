using SolidPrinciples.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Models
{
    public class CanalSms : ICanaMensaje
    {
        public void Enviar(Mensaje mensaje)
        {
            Console.WriteLine($"Enviando sms : { mensaje.Contenido} - {mensaje.Titulo} ");
        }
    }
}
