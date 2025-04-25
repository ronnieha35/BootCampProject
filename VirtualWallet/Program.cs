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
            BindData();
            Usuario usuarioActual = null;
            

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=============================");
                Console.WriteLine("=== Billetera Electrónica ===");
                Console.WriteLine("=============================\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Crear Usuario");
                Console.WriteLine("2. Iniciar Sesión");
                Console.WriteLine("3. Salir\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                Console.ResetColor();

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

        #region Usuario
        static void CrearUsuario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Crear Nuevo Usuario ===\n");
            Console.WriteLine("Presione 'Esc' en cualquier momento para cancelar.\n");
            Console.ResetColor();


            Console.Write("Ingrese nombre de usuario: ");
            string nombres = Console.ReadLine();

            Console.Write("Correo: ");
            string correo = Console.ReadLine();

            Console.Write("Usuario: ");
            string user = Console.ReadLine();

            Console.Write("Clave: ");
            string password = Console.ReadLine();

            // Validar si los campos son válidos
            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Todos los campos deben ser completados.");
                Console.ResetColor();
                Console.WriteLine("\nPresione una tecla para regresar al menú...");
                Console.ReadKey();
                return;
            }

            Usuario nuevoUsuario = new Usuario
            {
                Nombre = nombres,
                Correo = correo,
                User = user,
                Password = password
            };

            usuariorepository.SaveUser(nuevoUsuario);
        }

        static Usuario IniciarSesion()
        {
            Console.Write("Usuario: ");
            string user = Console.ReadLine();

            Console.Write("Clave: ");
            string clave = LeerClave();

            Usuario usuario = usuariorepository.GetbyUser(user);

            if (usuario != null && usuario.Password == clave)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                return usuario;
            }

            Console.WriteLine("Credenciales incorrectas.");
            return null;
        }

        static string LeerClave(string claveActual = "")
        {

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return claveActual;
            }
            else if (key.Key == ConsoleKey.Backspace && claveActual.Length > 0)
            {
                claveActual = claveActual.Substring(0, claveActual.Length - 1);
                int pos = Console.CursorLeft;
                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                Console.Write(" ");
                Console.SetCursorPosition(pos - 1, Console.CursorTop);
            }
            else if (!char.IsControl(key.KeyChar))
            {
                claveActual += key.KeyChar;
                Console.Write("*");
            }

            return LeerClave(claveActual); // Recursión
        }

        private static void MenuUsuario(Usuario usuario)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=============================");
                Console.WriteLine("=== Billetera Electrónica ===");
                Console.WriteLine($"=== Bienvenido, {usuario.Nombre} ===");
                Console.WriteLine("=============================\n");
                Console.ResetColor();


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Ver Saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("4. Transferir");
                Console.WriteLine("5. Ver Transacciones");
                Console.WriteLine("6. Editar Usuario");
                Console.WriteLine("7. Mostrar Datos Usuario");
                Console.WriteLine("8. Cerrar Sesión\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                Console.ResetColor();

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
                        EditarUsuario(usuario);
                        break;

                    case "7":
                        MostrarDatosUsuario(usuario);
                        break;

                    case "8":
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

        private static void MostrarDatosUsuario(Usuario usuario)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.WriteLine($"=== Usuario :, {usuario.Nombre} ===");
            Console.WriteLine("=====================================\n");
            Console.ResetColor();

            Usuario? user = usuariorepository.GetbyIdUsuario(usuario.IdUsuario);



            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ID | Nombre | User | Fecha Creacion | FechaModificacion ");
            Console.WriteLine("  " + new string('-', 80));




            Console.WriteLine($"  {user.IdUsuario} | {user.Nombre} | {user.User} | {user.FechaCreacion.ToShortDateString()} | {(user.FechaModificacion.HasValue ? user.FechaModificacion.Value.ToShortDateString() : "Sin modificar")}");


           
            Console.ReadKey();
        }
            

        private static void EditarUsuario(Usuario usuario)
        {
            ConsoleKeyInfo key;
           

            bool salir = true;
            bool isUpdate = false;

            while (salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n=== Editar Usuario ({usuario.Nombre})===\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Editar Nombre");
                Console.WriteLine("2. Editar Correo");
                Console.WriteLine("3. Cambiar Contraseña");
                Console.WriteLine("4. Regresar al menú principal\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                Console.ResetColor();

                switch (opcion)
                {
                    case "1":

                        // Editar Nombre
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"Nombre actual: {usuario.Nombre}");
                        Console.Write("Ingrese el nuevo nombre (Presione 'Esc' para no modificar): ");
                        key = Console.ReadKey(intercept: true);

                        if (key.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("\nEdición cancelada.");
                            break;
                        }

                        string nuevoNombre = Console.ReadLine();

                        if (nuevoNombre.ToLower() == "esc")
                        {
                            Console.WriteLine("No se realizó ningun cambio en el nombre.");
                        }
                        else if (!string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            usuario.Nombre = nuevoNombre;
                            isUpdate = true;
                        }
                        else
                        {
                            Console.WriteLine("El nombre no puede estar vacio.");
                        }
                        Console.ResetColor();

                        break;

                    case "2":
                        // Editar Correo
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"Correo actual: {usuario.Correo}");
                        Console.Write("Ingrese el correo nombre (Presione 'Esc' para no modificar): ");
                        key = Console.ReadKey(intercept: true);

                        if (key.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("\nEdición cancelada.");
                            break;
                        }



                        string nuevoCorreo = Console.ReadLine();

                        if (nuevoCorreo.ToLower() == "esc")
                        {
                            Console.WriteLine("No se realizó ningun cambio en el correo.");
                        }
                        else if (!string.IsNullOrWhiteSpace(nuevoCorreo) && nuevoCorreo.Contains("@"))
                        {
                            usuario.Correo = nuevoCorreo;
                            isUpdate = true;
                        }
                        else
                        {
                            Console.WriteLine("Correo invalido.");
                        }
                        Console.ResetColor();

                        break;
                    case "3":
                        // Cambiar Contraseña
                        Console.WriteLine($"Contraseña actual: {usuario.Password}");
                        Console.Write("Ingrese la contraseña nueva (Presione 'Esc' para no modificar): ");
                        key = Console.ReadKey(intercept: true);

                        if (key.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("\nEdición cancelada.");
                            break;
                        }


                        string nuevaClave = LeerClave(); 

                        if (nuevaClave.ToLower() == "esc")
                        {
                            Console.WriteLine("No se realizo ningun cambio en la contraseña.");
                        }
                        else if (!string.IsNullOrWhiteSpace(nuevaClave))
                        {
                            usuario.Password = nuevaClave;
                            isUpdate = true;

                        }
                        else
                        {
                            Console.WriteLine("La contraseña no puede estar vacia.");
                        }
                        break;

                    case "4":
                        
                        salir = false;
                        break;

                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }

                if (salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            if (isUpdate)
            {
                usuario.FechaModificacion = DateTime.Now;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLos datos se guardaron correctamente.");
                Console.ReadKey();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo se realizaron cambios.");
                Console.ResetColor();
            }

          
        }
        #endregion


        static void BindData()
        {
            IUsuario usuarioRepository = new UsuarioRepository();

            Usuario usuario = new Usuario()
            {
                Nombre = "Ronnie Alarcon Morales",
                Correo = "ronniealarcon@gmail.com",
                User = "ralarcon",
                Password = "admin123",
                FechaCreacion = DateTime.Now.Date
            };

            usuariorepository.SaveUser(usuario);
        }

    }
}
