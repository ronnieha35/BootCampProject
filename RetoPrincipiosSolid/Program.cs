﻿namespace RetoPrincipiosSolid
{
    internal class Program
    {
        //Principio de Segregacion (ISP) estan seperadas segun lo que se necesite implementar
        public interface IReserva
        {
            bool CrearReserva(string clienteId, DateTime fechaInicio, DateTime fechaFin);
            bool CancelarReserva(string reservaId);
        }

        //Principio de Segregacion (ISP) estan seperadas segun lo que se necesite implementar
        public interface IPago
        {
            bool ProcesarPago(decimal monto, string metodoPago, string referencia);
        }


        //Abierto Cerrado (OCP) permite agregar nuevos tipos de notificacion sin modificar la clase sistemaReservacion
        //Principio de Segregacion (ISP) estan seperadas segun lo que se necesite implementar
        public interface INotificacion
        {
            void EnviarConfirmacion(string destinatario, string detalles);
        }


        //Principio de Responsabilidad Simple (SRP) Solo Procesan Pagos
        //Abierto Cerrado (OCP) es una clase abstracta que puede extener nuevos metodos TC y Paypal sin modificar codigo
        public abstract class MetodoPago
        {
            public abstract bool Procesar(decimal monto, string referencia);
        }

        //Principio de Responsabilidad Simple (SRP) Solo Procesan Pagos
        //Principio de Sustitucion Liskow (LSP) heran de metodoPago y se puede sustituir sin errores
        public class TarjetaCredito : MetodoPago
        {
            public override bool Procesar(decimal monto, string referencia)
            {
                Console.WriteLine($"Procesando pago con la tarjeta: ${monto} -  Ref: {referencia}");
                return true;
            }
        }

        //Principio de Responsabilidad Simple (SRP) Solo Procesan Pagos
        //Principio de Sustitucion Liskow (LSP) heran de metodoPago y se puede sustituir sin errores
        public class Paypal : MetodoPago
        {
            public override bool Procesar(decimal monto, string referencia)
            {
                Console.WriteLine($"Procesando pago con Paypal: ${monto} -  Ref: {referencia}");
                return true;
            }
        }

        //Principio de Responsabilidad Simple (SRP) Solo Procesan Pagos
        //Principio de Sustitucion Liskow (LSP) heran de metodoPago y se puede sustituir sin errores
        public class Transferencia : MetodoPago
        {
            public override bool Procesar(decimal monto, string referencia)
            {
                Console.WriteLine($"Procesando pago con transferencia: ${monto} -  Ref: {referencia}");
                return true;
            }
        }

        //Principio de Responsabilidad Simple (SRP) solo envian notificaciones.
        //Principio de Sustitucion Liskow (LSP) implementa INotifiacion 
        public class EmailNotificacion : INotificacion
        {
            public void EnviarConfirmacion(string destinatario, string detalles)
            {
                Console.WriteLine($"Enviando email a {destinatario}: {detalles}");
            }
        }

        //Principio de Responsabilidad Simple (SRP) solo envian notificaciones.
        //Principio de Sustitucion Liskow (LSP) implementa INotifiacion 
        public class SmsNotificacion : INotificacion
        {
            public void EnviarConfirmacion(string destinatario, string detalles)
            {
                Console.WriteLine($"Enviando SMS a {destinatario}: {detalles}");
            }
        }

        //Principio de Responsabilidad Simple (SRP) Solo Maneja el Guardado y recuperacion de Reservas
        //
        public class PersistenciaReserva
        {
            public void GuardarReserva(Reserva reserva)
            {
                Console.WriteLine($"Guardando reserva: {reserva} en la base de datos");
            }

            public Reserva ObtenerReserva(string id)
            {
                Console.WriteLine($"Recuperando reserva: {id}");
                return new Reserva { Id = id };
            }
        }

        //Principio de Responsabilidad Simple (SRP) Representa un modelo de datos
        //
        public class Reserva
        {
            public string Id { get; set; }
            public string ClienteId { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public decimal Monto { get; set; }
            public string Estado { get; set; }
        }

        //Principio de Responsabilidad Simple (SRP) Solo registra Eventos
        // 
        public class Logger
        {
            public void RegistrarEvento(string mensaje)
            {
                Console.WriteLine("Registrando evento");
            }
        }

        //Principio de Segregacion (ISP) Implementa IReserva e IPago segun corresponda
        //Principio de Inversion de Dependencia (DIP) recibe el constructor de INotificacion y de Metodo Pago dependiendo de ambos
        public class SistemaReservacion : IReserva, IPago
        {
            private readonly PersistenciaReserva _persistencia;
            private readonly INotificacion _notificador;
            private readonly MetodoPago _metodoPago;
            private readonly Logger _logger;

            public SistemaReservacion(
                PersistenciaReserva persistencia,
                INotificacion notificador,
                MetodoPago metodoPago,
                Logger logger)
            {
                _persistencia = persistencia;
                _notificador = notificador;
                _metodoPago = metodoPago;
                _logger = logger;
            }

            public bool CrearReserva(string clienteId, DateTime fechaInicio, DateTime fechaFin)
            {
                try
                {
                    // Calcular días y monto
                    var dias = (fechaFin - fechaInicio).Days;
                    if (dias <= 0)
                    {
                        _logger.RegistrarEvento($"Fechas inválidas para reserva del cliente {clienteId}");
                        return false;
                    }

                    var monto = dias * 100.0m; // $100 por noche

                    // Crear objeto reserva
                    var reserva = new Reserva
                    {
                        Id = Guid.NewGuid().ToString(),
                        ClienteId = clienteId,
                        FechaInicio = fechaInicio,
                        FechaFin = fechaFin,
                        Monto = monto,
                        Estado = "Pendiente"
                    };

                    // Persistir la reserva
                    _persistencia.GuardarReserva(reserva);
                    _logger.RegistrarEvento($"Reserva creada: {reserva.Id} para cliente {clienteId}");

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.RegistrarEvento($"Error al crear reserva: {ex.Message}");
                    return false;
                }
            }

            public bool CancelarReserva(string reservaId)
            {
                try
                {
                    // Obtener la reserva
                    var reserva = _persistencia.ObtenerReserva(reservaId);
                    if (reserva == null)
                    {
                        _logger.RegistrarEvento($"Reserva no encontrada: {reservaId}");
                        return false;
                    }

                    // Actualizar estado
                    reserva.Estado = "Cancelada";
                    _persistencia.GuardarReserva(reserva);

                    // Notificar al cliente
                    _notificador.EnviarConfirmacion(
                        reserva.ClienteId,
                        $"Su reserva {reservaId} ha sido cancelada exitosamente."
                    );

                    _logger.RegistrarEvento($"Reserva cancelada: {reservaId}");
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.RegistrarEvento($"Error al cancelar reserva: {ex.Message}");
                    return false;
                }
            }

            public bool ProcesarPago(decimal monto, string metodoPago, string referencia)
            {
                try
                {
                    var resultado = _metodoPago.Procesar(monto, referencia);
                    if (resultado)
                    {
                        _logger.RegistrarEvento($"Pago procesado: {monto} con referencia {referencia}");
                    }
                    else
                    {
                        _logger.RegistrarEvento($"Pago fallido: {monto} con referencia {referencia}");
                    }
                    return resultado;
                }
                catch (Exception ex)
                {
                    _logger.RegistrarEvento($"Error procesando pago: {ex.Message}");
                    return false;
                }
            }
        }

        static void Main(string[] args)
        {
            // Crear las dependencias
            var persistencia = new PersistenciaReserva();
            var notificador = new EmailNotificacion();
            var metodoPago = new TarjetaCredito();
            var logger = new Logger();

            // Crear el sistema de reserva
            var sistema = new SistemaReservacion(persistencia, notificador, metodoPago, logger);

            // Crear una reserva
            var exito = sistema.CrearReserva("cliente123", DateTime.Now, DateTime.Now.AddDays(3));
            if (exito)
            {
                Console.WriteLine("Reserva creada exitosamente");
                sistema.ProcesarPago(300.0m, "tarjeta", "1234-5678");
            }

            Console.WriteLine("\nProbando con diferente método de pago:");
            var sistemaPayPal = new SistemaReservacion(persistencia, notificador, new Paypal(), logger);
            sistemaPayPal.ProcesarPago(300.0m, "paypal", "paypal@cliente.com");

            Console.WriteLine("\nProbando con diferente notificador:");
            var sistemaSMS = new SistemaReservacion(persistencia, new SmsNotificacion(), metodoPago, logger);
            sistemaSMS.CrearReserva("cliente456", DateTime.Now, DateTime.Now.AddDays(5));

            Console.ReadLine();
        }
    }
}
