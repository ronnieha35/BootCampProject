using System.Transactions;

namespace SolidPrincipalsPractice2
{
    internal class Program
    {
        //Principio de Reponsabilidad unica
        public interface INotificacionServices
        {
            void EnviarNotificacion(string mensaje, string destinatrio);
        }

        //Principio de sustitucion de Liskow
        public class EmailService : INotificacionServices
        {
            public void EnviarNotificacion(string mensaje, string destinatrio)
            {
                Console.WriteLine($"Enviando email a  {destinatrio}: {mensaje}");
            }
        }

        public class smsServico : INotificacionServices
        {
            public void EnviarNotificacion(string mensaje, string destinatrio)
            {
                Console.WriteLine($"Enviando sms a  {destinatrio}: {mensaje}");
            }
        }

        //Inversion de dependencia
        public class NotificacionManager
        {
            private readonly INotificacionServices _notificacionservices;

            public NotificacionManager(INotificacionServices notificacionservices)
            {
                _notificacionservices = notificacionservices;
            }

            private void NotificaUsuario(string mensaje, string destinatario)
            {
                _notificacionservices.EnviarNotificacion(mensaje, destinatario);
            }

            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


    }
}
