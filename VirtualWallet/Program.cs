using VirtualWallet.Interfaces;
using VirtualWallet.Models;
using VirtualWallet.Repository;

namespace VirtualWallet
{
    internal class Program
    {
        static IUsuario usuariorepository = new UsuarioRepository();
        static IBilletera billeterarepository = new BillteraRepository();
        static void Main(string[] args)
        {

            Usuario usuarioActual = null;
            

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Billetera Electrónica ===");
                Console.WriteLine("1. Crear Usuario");
                Console.WriteLine("2. Iniciar Sesión");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearUsuario();
                        break;

                    case "2":
                        usuarioActual = IniciarSesion();
                        if (usuarioActual != null)
                            MenuUsuario(usuarioActual);
                        break;

                    case "3":
                        Console.WriteLine("¡Hasta luego!");
                        return;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        
        static void CrearUsuario()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Correo: ");
            string correo = Console.ReadLine();

            Console.Write("Usuario: ");
            string user = Console.ReadLine();

            Console.Write("Clave: ");
            string clave = Console.ReadLine();

            Usuario nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                User = user,
                Clave = clave
            };

            usuariorepository.CrearUsuario(nuevoUsuario);
        }

        static Usuario IniciarSesion()
        {
            Console.Write("Usuario: ");
            string user = Console.ReadLine();

            Console.Write("Clave: ");
            string clave = Console.ReadLine();

            Usuario usuario = usuariorepository.GetbyUser(user);

            if (usuario != null && usuario.Clave == clave)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                return usuario;
            }

            Console.WriteLine("Credenciales incorrectas.");
            return null;
        }

        private static void MenuUsuario(Usuario usuario)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine($"=== Bienvenido, {usuario.Nombre} ===");
                Console.WriteLine("1. Ver Saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("4. Transferir");
                Console.WriteLine("5. Ver Transacciones");
                Console.WriteLine("6. Cerrar Sesión");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        decimal saldo = billeterarepository.ObtenerSaldo(usuario);
                        Console.WriteLine($"Saldo actual: S/ {saldo:N2}");
                        break;

                    case "2":
                        Console.Write("Monto a depositar: S/ ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal deposito))
                            billeterarepository.Depositar(usuario, deposito);
                        else
                            Console.WriteLine("Monto inválido.");
                        break;

                    case "3":
                        Console.Write("Monto a retirar: S/ ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal retiro))
                            billeterarepository.Retirar(usuario, retiro);
                        else
                            Console.WriteLine("Monto inválido.");
                        break;

                    case "4":
                        Console.WriteLine("Usuarios disponibles para transferir:");
                        foreach (var u in usuariorepository.GetAllUsers().Where(u => u.User != usuario.User))
                        {
                            Console.WriteLine($"- {u.Nombre} ({u.User})");
                        }

                        Console.Write("Usuario destino: ");
                        string destinoUser = Console.ReadLine();
                        Usuario destino = usuariorepository.GetbyUser(destinoUser);

                        if (destino == null)
                        {
                            Console.WriteLine("Usuario no encontrado.");
                            break;
                        }

                        Console.Write("Monto a transferir: S/ ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal montoTransferencia))
                            billeterarepository.Transferir(usuario, destino, montoTransferencia);
                        else
                            Console.WriteLine("Monto inválido.");
                        break;

                    case "5":
                        Console.WriteLine("=== Transacciones ===");
                        foreach (var t in billeterarepository.ObtenerTransacciones(usuario))
                        {
                            Console.WriteLine($"{t.Fecha:dd/MM/yyyy HH:mm} | {t.Tipo} | S/ {t.Monto:N2} | {t.Detalle}");
                        }
                        break;

                    case "6":
                        salir = true;
                        Console.WriteLine("Sesión cerrada.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

    }
}
