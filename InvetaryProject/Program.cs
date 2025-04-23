namespace InvetaryProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            SistemaInventario sistema = new SistemaInventario();
            CargarDatosIniciales(sistema);

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nMenu Principal");
                Console.WriteLine("1. Gestion de Empleados");
                Console.WriteLine("2. Gestion de Productos");
                Console.WriteLine("3. Movimientos de Stock");
                Console.WriteLine("4. Reportes");
                Console.WriteLine("0. Salir");

                Console.WriteLine("\n Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            GestionEmpleados(sistema);
                            break;
                        case "2":
                            GestionProductos(sistema);
                            break;
                        case "3":
                            GestionarMovimientos(sistema);
                            break;
                        case "4":
                            MostrarReportes(sistema);
                            break;
                        case "0":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private static void MostrarReportes(SistemaInventario sistema)
        {
            throw new NotImplementedException();
        }



        #region Movimientos de Stock
        private static void GestionarMovimientos(SistemaInventario sistema)
        {
            bool regresar = false;

            while (!regresar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("************ GESTION DE MOVIMIENTOS ************");

                Console.WriteLine("\n MENU DE MOVIMIENTOS\n");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("  [1] Generar Movimiento");
                Console.WriteLine("  [2] Listar todos los movimientos");
                Console.WriteLine("  [0] Volver al Menú Principal\n");



                try
                {
                    int tecla = int.Parse(Console.ReadLine());

                    switch (tecla)
                    {
                        case 1:
                            GenerarMovimientos(sistema);
                            break;
                        case 2:
                            ListarMovimientos(sistema);
                            break;
                        case 0:
                            regresar = true;
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception)
                {

                    throw;
                }


            }
        }

        private static void ListarMovimientos(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== HISTORIAL DE MOVIMIENTOS DE STOCK ===\n");

            var movimientos = sistema.ObtenerMovimientos();

            if (movimientos.Count == 0)
            {
                Console.WriteLine("⚠ No hay movimientos registrados.");
                Console.ReadKey();
                return;
            }

            // Encabezado
            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-10} {5,-12}",
                "ID", "Producto", "Empleado", "Tipo Movimiento", "Cantidad", "Fecha");

            Console.WriteLine(new string('-', 90));

            // Detalle
            foreach (var m in movimientos)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-10} {5,-12}",
                    m.Id,
                    m.Producto.Nombre,
                    m.Empleado.Nombre,
                    m.tipoMovimiento,
                    m.Cantidad,
                    m.FechaCreacion.ToShortDateString());
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void GenerarMovimientos(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR MOVIMIENTO DE STOCK ===\n");

            // Mostrar productos disponibles
            var productos = sistema.ObtenerProductos();
            if (productos.Count == 0)
            {
                Console.WriteLine(" No hay productos registrados.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Seleccione un producto:\n");
            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {productos[i].Nombre} (SKU: {productos[i].Sku}) - Stock: {productos[i].Stock}");
            }

            Console.Write("\nIngrese la opción del producto: ");
            if (!int.TryParse(Console.ReadLine(), out int opcionProducto) || opcionProducto < 1 || opcionProducto > productos.Count)
            {
                Console.WriteLine(" Selección inválida.");
                Console.ReadKey();
                return;
            }

            var productoSeleccionado = productos[opcionProducto - 1];

            // Seleccionar empleado
            var empleados = sistema.ObtenerEmpleados();
            if (empleados.Count == 0)
            {
                Console.WriteLine(" No hay empleados registrados.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nSeleccione el empleado que realiza el movimiento:\n");
            for (int i = 0; i < empleados.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {empleados[i].Nombre} (ID: {empleados[i].Id})");
            }

            Console.Write("\nIngrese la opción del empleado: ");
            if (!int.TryParse(Console.ReadLine(), out int opcionEmpleado) || opcionEmpleado < 1 || opcionEmpleado > empleados.Count)
            {
                Console.WriteLine(" Selección inválida.");
                Console.ReadKey();
                return;
            }

            var empleadoSeleccionado = empleados[opcionEmpleado - 1];

            // Tipo de movimiento
            Console.WriteLine("\nSeleccione el tipo de movimiento:\n  [1] ENTRADA\n  [2] SALIDA");
            TipMovimiento tipoMovimiento;
            string tipoEntrada = Console.ReadLine();

            if (tipoEntrada == "1")
            {
                tipoMovimiento = TipMovimiento.ENTRADA;
            }
            else if (tipoEntrada == "2")
            {
                tipoMovimiento = TipMovimiento.SALIDA;
            }
            else
            {
                Console.WriteLine(" Opción inválida.");
                Console.ReadKey();
                return;
            }

            // Cantidad del movimiento
            Console.Write("\nIngrese la cantidad del movimiento: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                Console.WriteLine(" Cantidad inválida.");
                Console.ReadKey();
                return;
            }

            // Validar stock en caso de salida
            if (tipoMovimiento == TipMovimiento.SALIDA && cantidad > productoSeleccionado.Stock)
            {
                Console.WriteLine($" No hay suficiente stock disponible. Stock actual: {productoSeleccionado.Stock}");
                Console.ReadKey();
                return;
            }

            // Actualizar stock
            if (tipoMovimiento == TipMovimiento.ENTRADA)
                productoSeleccionado.Stock += cantidad;
            else
                productoSeleccionado.Stock -= cantidad;

            // Registrar movimiento
            var movimiento = new MovimientoStock
            {
                Producto = productoSeleccionado,
                Empleado = empleadoSeleccionado,
                Cantidad = cantidad,
                tipoMovimiento = tipoMovimiento,
                FechaCreacion = DateTime.Now
            };

            sistema.AgregarMovimientoStock(movimiento); // Método que debes implementar en SistemaInventario

            Console.WriteLine($"\n Movimiento registrado con éxito. Nombre Producto: {productoSeleccionado.Nombre} Nuevo stock: {productoSeleccionado.Stock}");
            Console.ReadKey();
        }

      

        #endregion

        #region Empleados
        private static void GestionEmpleados(SistemaInventario sistema)
        {
            bool regresar = false;

            while (!regresar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("************ GESTION DE EMPLEADOS ************");

                Console.WriteLine("\n MENU DE EMPLEADOS\n");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("  [1] Agregar Nuevo Empleado");
                Console.WriteLine("  [2] Buscar Empleado");
                Console.WriteLine("  [3] Listar Todos los Empleados");
                Console.WriteLine("  [4] Modificar Empleado");
                Console.WriteLine("  [5] Cambiar Estado de Empleado");
                Console.WriteLine("  [6] Gestión de Tipos de Empleado");
                Console.WriteLine("  [0] Volver al Menú Principal\n");



                try
                {
                    int tecla = int.Parse(Console.ReadLine());

                    switch (tecla)
                    {
                        case 1:
                            AgregarEmpleado(sistema);
                            break;
                        case 2:
                            BuscarEmpleado(sistema);
                            break;
                        case 3:
                            ListarEmpleados(sistema);
                            break;
                        case 4:
                            ModificarEmpleado(sistema);
                            break;
                        case 5:
                            CambiarEstadoEmpleado(sistema);
                            break;
                        case 6:
                            GestionTiposEmpleado(sistema);
                            break;
                        case 0:
                            regresar = true;
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception)
                {

                    throw;
                }


            }
        }

        private static void GestionTiposEmpleado(SistemaInventario sistema)
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("\n  GESTIÓN DE TIPOS DE EMPLEADO\n");
                Console.WriteLine("  [1] Listar Tipos de Empleado");
                Console.WriteLine("  [2] Agregar Tipo de Empleado");
                Console.WriteLine("  [0] Volver\n");

                int opcion = LeerEntero("  Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        var tipos = sistema.ObtenerTipoEmpleado();
                        Console.WriteLine("\n  Tipos de Empleado Registrados:");
                        foreach (var tipo in tipos)
                        {
                            Console.WriteLine($"  - {tipo.Nombre} ({tipo.Descripcion})");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        string nombre = LeerTexto("  Nombre del tipo: ");
                        string descripcion = LeerTexto("  Descripción: ");
                        sistema.AgregarTipoEmpleado(new TipoEmpleado
                        {
                            Nombre = nombre,
                            Descripcion = descripcion
                        });
                        Console.WriteLine("  Tipo de empleado agregado correctamente.");
                        Console.ReadKey();
                        break;
                    case 0:
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("  Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CambiarEstadoEmpleado(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("\n  CAMBIAR ESTADO DE EMPLEADO\n");

            int id = LeerEntero("  Ingrese el ID del empleado: ");
            var empleado = sistema.ObtenerEmpleadoPorId(id);

            if (empleado == null)
            {
                Console.WriteLine("  Empleado no encontrado.");
                return;
            }

            Console.WriteLine($"  Estado actual: {empleado.Estado}");
            Console.WriteLine("  Seleccione nuevo estado:");
            Console.WriteLine("  [1] ACTIVO");
            Console.WriteLine("  [2] INACTIVO");

            int estadoNuevo = LeerEntero("  Opción: ");
            if (estadoNuevo == 1)
                empleado.Estado = EstadoEmpleado.ACTIVO;
            else if (estadoNuevo == 2)
                empleado.Estado = EstadoEmpleado.INACTIVO;
            else
                Console.WriteLine("  Estado inválido.");

            Console.WriteLine("\n Estado actualizado correctamente.");
            Console.ReadKey();
        }

        private static void ModificarEmpleado(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("\n  MODIFICAR EMPLEADO\n");

            int id;
            while (true)
            {
                Console.Write("  Ingrese el ID del empleado que desea modificar: ");
                string inputId = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputId))
                {
                    Console.WriteLine("  ⚠ El ID no puede estar vacío.");
                    continue;
                }

                if (!int.TryParse(inputId, out id))
                {
                    Console.WriteLine("  ⚠ Debe ingresar un número válido.");
                    continue;
                }

                break;
            }

            var empleado = sistema.ObtenerEmpleadoPorId(id);
            if (empleado == null)
            {
                Console.WriteLine("  ❌ Empleado no encontrado.");
                return;
            }

            //Modificar Nombres
            Console.WriteLine($"\n  Nombre actual: {empleado.Nombre}");
            string nuevoNombre = LeerTexto("  Nuevo nombre (Enter para dejar igual): ");
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                empleado.Nombre = nuevoNombre;

            //Modificar Edad
            Console.WriteLine($"\n  Edad actual: {empleado.Edad}");
            string nuevaEdad = LeerTexto("  Nueva edad (Enter para dejar igual): ");
            if (int.TryParse(nuevaEdad, out int edad))
                empleado.Edad = edad;

            //Modificar Genero
            Console.WriteLine($"\n  Género actual: {empleado.genero}");
            string nuevoGenero = LeerTexto("  Nuevo género (MASCULINO/FEMENINO o Enter para dejar igual): ");
            if (!string.IsNullOrWhiteSpace(nuevoGenero) && Enum.TryParse(nuevoGenero.ToUpper(), out Genero genero))
                empleado.genero = genero;

            //Modificar TipoEmpleado

            Console.WriteLine($"\n  Tipo actual: {empleado.TipoEmpleado.Nombre}");
            Console.Write("  ¿Desea cambiar el tipo de empleado? (s/n): ");
            string opcionTipo = Console.ReadLine().Trim().ToLower();
            if (opcionTipo == "s")
            {
                var nuevoTipo = MostrarTipoEmpleados(sistema);

                if (nuevoTipo != null)
                    empleado.TipoEmpleado = nuevoTipo;

            }

            empleado.FechaModificacion = DateTime.Now;

            Console.WriteLine("\n Empleado modificado exitosamente.");
            Console.ReadKey();
        }

        static void AgregarEmpleado(SistemaInventario sistema)
        {
            Console.WriteLine("\n Agregar un Nuevo Empleado");

            Console.WriteLine("Nombre del Empleado :");
            string nombres = Console.ReadLine();

            Console.WriteLine("Tipo de Empleado :");
            var tipoEmpleados = sistema.ObtenerTipoEmpleado();

            if (tipoEmpleados.Count == 0)
            {
                Console.WriteLine("No hya ningun tipo de Empleado");
                return;
            }

            Console.WriteLine("Tipos de Empleados Disponibles: ");

            for (int i = 0; i < tipoEmpleados.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, tipoEmpleados[i].Nombre);
            }

            Console.WriteLine("Seleccionar el tipo de Empleado: ");

            if (!int.TryParse(Console.ReadLine(), out int tipoindice) || tipoindice < 0)
            {
                Console.WriteLine("Seleccion invalida.");
                return;
            }

            var tipoSeleccionado = tipoEmpleados[tipoindice];

            Console.WriteLine("Ingrese la edad del Empleado: ");
            int edad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese su genero con la palabra MASCULINO o FEMENINO");
            Genero genero = (Genero)Convert.ToInt32(Console.ReadLine()); // 1 = Masculino

            string fechaIngreso = DateTime.Now.Date.ToString("dd/MM/yyyy");

            var empleado = new Empleado
            {
                Nombre = nombres,
                TipoEmpleado = tipoSeleccionado,
                Estado = EstadoEmpleado.ACTIVO,
                FechaIngreso = DateTime.Parse(fechaIngreso),
                Edad = edad,
                genero = genero,
            };


            sistema.AgregarEmpleado(empleado);
            Console.WriteLine($"\n Empleado agregado con el ID: {empleado.Id}");

            

        }

        private static void BuscarEmpleado(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("\n  BUSCAR EMPLEADO\n");

            try
            {
                Console.WriteLine("  [1] Buscar por ID");
                Console.WriteLine("  [2] Buscar por Nombre");
                int opcion = LeerEntero("\n  Seleccione una opción: ");

                Empleado? empleado = null;

                if (opcion == 1)
                {
                    int id = LeerEntero("  Ingrese el ID del empleado: ");
                    empleado = sistema.ObtenerEmpleadoPorId(id);
                }
                else if (opcion == 2)
                {
                    string nombre = LeerTexto("  Ingrese el nombre del empleado: ");
                    var empleados = sistema.ObtenerEmpleados().Where(e => e.Nombre.ToLower().Contains(nombre.ToLower())).ToList();

                    if (empleados.Count > 1)
                    {
                        Console.WriteLine("\n  Se encontraron varios empleados:");
                        foreach (var emp in empleados)
                        {
                            Console.WriteLine($"  [{emp.Id}] {emp.Nombre}");
                        }
                        int id = LeerEntero("\n  Seleccione el ID específico: ");
                        empleado = sistema.ObtenerEmpleadoPorId(id);
                    }
                    else if (empleados.Count == 1)
                    {
                        empleado = empleados[0];
                    }
                }

                if (empleado != null)
                {
                    MostrarDetalleEmpleado(empleado);
                }
                else
                {
                    Console.WriteLine("  No se encontró ningún empleado con esos criterios.");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write("  Seleccione una opción: ");
            }
        }

        private static void ListarEmpleados(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("\n  LISTA DE EMPLEADOS\n");

            try
            {


                var empleados = sistema.ObtenerEmpleados();

                if (empleados.Count == 0)
                {
                    Console.WriteLine("\n  No hay empleados registrados en el sistema.");
                }
                else
                {
                    // Opciones de filtrado
                    Console.WriteLine("\n  Filtros:");
                    Console.WriteLine("  [1] Todos los empleados");
                    Console.WriteLine("  [2] Solo empleados activos");
                    Console.WriteLine("  [3] Solo empleados inactivos");
                    Console.Write("\n  Seleccione un filtro: ");

                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    Console.WriteLine(tecla.KeyChar);


                    List<Empleado> filtrados;

                    switch (tecla.KeyChar)
                    {
                        case '1':
                            filtrados = empleados;
                            break;
                        case '2':
                            filtrados = empleados.Where(e => e.Estado == EstadoEmpleado.ACTIVO).ToList();
                            break;
                        case '3':
                            filtrados = empleados.Where(e => e.Estado != EstadoEmpleado.INACTIVO).ToList();
                            break;
                        default:
                            filtrados = empleados;
                            break;
                    }

                    // Mostrar tabla de empleados
                    MostrarTablaEmpleados(filtrados);

                    static void MostrarTablaEmpleados(List<Empleado> empleados)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n  ID | Nombre | Tipo | Estado | Fecha Ingreso | Edad | Género");
                        Console.WriteLine("  " + new string('-', 80));

                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var emp in empleados)
                        {
                            // Colorear según estado
                            if (emp.Estado == EstadoEmpleado.ACTIVO)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else if (emp.Estado == EstadoEmpleado.INACTIVO)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else
                                Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine($"  {emp.Id} | {emp.Nombre} | {emp.TipoEmpleado.Nombre} | {emp.Estado} | {emp.FechaIngreso.ToShortDateString()} | {emp.Edad} | {emp.genero}");
                        }

                        Console.ReadKey();
                    }
                }

                Console.WriteLine("\n  Presione cualquier tecla para volver...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }


        }

        static void MostrarDetalleEmpleado(Empleado empleado)
        {
            Console.Clear();
            Console.WriteLine($"\n  DETALLE DEL EMPLEADO - ID: {empleado.Id}\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Nombre: {empleado.Nombre}");
            Console.WriteLine($"  Tipo: {empleado.TipoEmpleado.Nombre}");
            Console.WriteLine($"  Estado: {empleado.Estado}");
            Console.WriteLine($"  Fecha de Ingreso: {empleado.FechaIngreso.ToShortDateString()}");
            Console.WriteLine($"  Edad: {empleado.Edad}");
            Console.WriteLine($"  Género: {empleado.genero}");
            Console.WriteLine($"  Fecha de Creación: {empleado.FechaCreacion}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static TipoEmpleado MostrarTipoEmpleados(SistemaInventario sistema)
        {
            var tipoEmpleados = sistema.ObtenerTipoEmpleado();

            if (tipoEmpleados.Count == 0)
            {
                Console.WriteLine("  ⚠ No hay tipos de empleados disponibles.");
                return null;
            }

            Console.WriteLine("\n  Seleccione el tipo de empleado:");
            for (int i = 0; i < tipoEmpleados.Count; i++)
            {
                Console.WriteLine($"  [{i + 1}] {tipoEmpleados[i].Nombre}");
            }
            Console.WriteLine("  [0] Cancelar\n");

            while (true)
            {
                Console.Write("  Ingrese la opción correspondiente: ");
                string entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada) || entrada == "0")
                {
                    Console.WriteLine("  🔙 Selección cancelada.");
                    return null;
                }

                if (int.TryParse(entrada, out int tipoindice) &&
                    tipoindice > 0 && tipoindice <= tipoEmpleados.Count)
                {
                    return tipoEmpleados[tipoindice - 1]; // Ajustamos el índice
                }

                Console.WriteLine("  ⚠ Selección inválida. Intente de nuevo.");
            }
        }
        #endregion

        #region Productos
        private static void GestionProductos(SistemaInventario sistema)
        {
            bool regresar = false;

            while (!regresar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("************ GESTION DE PRODUCTOS ************");

                Console.WriteLine("\n MENU DE PRODUCTOS\n");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("  [1] Agregar Nuevo Producto");
                Console.WriteLine("  [2] Buscar Producto");
                Console.WriteLine("  [3] Listar Todos los Productos");
                Console.WriteLine("  [4] Modificar Producto");
                Console.WriteLine("  [0] Volver al Menú Principal\n");



                try
                {
                    int tecla = int.Parse(Console.ReadLine());

                    switch (tecla)
                    {
                        case 1:
                            AgregarNuevoProducto(sistema);
                            break;
                        case 2:
                            BuscarProducto(sistema);
                            break;
                        case 3:
                            ListarProducto(sistema);
                            break;
                        case 4:
                            ModificarProducto(sistema);
                            break;
                        case 0:
                            regresar = true;
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }


            }
        }

        private static void ModificarProducto(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== MODIFICAR PRODUCTO ===");

            int id = LeerEntero("Ingrese el ID del producto a modificar: ");
            var producto = sistema.ObtenerProductoPorId(id);

            if (producto == null)
            {
                Console.WriteLine(" Producto no encontrado.");
                return;
            }

            string nuevoSku = LeerTexto("Nuevo SKU (Enter para mantener): ");
            if (!string.IsNullOrWhiteSpace(nuevoSku)) producto.Sku = nuevoSku;

            string nuevoNombre = LeerTexto("Nuevo nombre (Enter para mantener): ");
            if (!string.IsNullOrWhiteSpace(nuevoNombre)) producto.Nombre = nuevoNombre;

            string nuevaDesc = LeerTexto("Nueva descripción (Enter para mantener): ");
            if (!string.IsNullOrWhiteSpace(nuevaDesc)) producto.Descripcion = nuevaDesc;

            string nuevoPrecio = LeerTexto("Nuevo precio (Enter para mantener): ");
            if (decimal.TryParse(nuevoPrecio, out decimal precio)) producto.Precio = precio;

            string nuevoStock = LeerTexto("Nuevo stock (Enter para mantener): ");
            if (int.TryParse(nuevoStock, out int stock)) producto.Stock = stock;

            Console.Write("¿Desea cambiar la categoría? (s/n): ");
            if (Console.ReadLine().Trim().ToLower() == "s")
            {
                var nuevaCategoria = SeleccionarCategoriaProducto();
                if (nuevaCategoria != null) producto.Categoria = nuevaCategoria.Value;
            }

            producto.FechaModificacion = DateTime.Now;
            Console.WriteLine(" Producto modificado exitosamente.");
            Console.ReadKey();
        }

        private static void ListarProducto(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PRODUCTOS ===\n");

            var productos = sistema.ObtenerProductos(); // Suponiendo que este método existe

            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("❌ No hay productos registrados.");
                return;
            }

            Console.WriteLine("ID".PadRight(5) + "SKU".PadRight(15) + "Nombre".PadRight(20) + "Categoría".PadRight(20) + "Precio".PadRight(15) + "Stock".PadRight(10) + "Fecha Creación");
            Console.WriteLine(new string('-', 95));

            foreach (var producto in productos)
            {
                Console.WriteLine(
                    $"{producto.Id.ToString().PadRight(5)}" +
                    $"{producto.Sku.PadRight(15)}" +
                    $"{producto.Nombre.PadRight(20)}" +
                    $"{producto.Categoria.ToString().PadRight(20)}" +
                    $"{producto.Precio.ToString("C").PadRight(15)}" +
                    $"{producto.Stock.ToString().PadRight(10)}" +
                    $"{producto.FechaCreacion.ToShortDateString()}"
                );
            }

            //Console.WriteLine("ID\tSKU\t\tNombre\t\tCategoría\tPrecio\tStock\tFechaCreacion");
            //Console.WriteLine("------------------------------------------------------------------------------------------------");

            //foreach (var producto in productos)
            //{
            //    Console.WriteLine($"{producto.Id}\t{producto.Sku}\t\t{producto.Nombre}\t\t{producto.Categoria}\t\t{producto.Precio:C}\t{producto.Stock}\t{producto.FechaCreacion.ToShortDateString()}");
            //}

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void BuscarProducto(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("\n  BUSCAR PRODUCTO\n");

            try
            {
                Console.WriteLine("  [1] Buscar por ID");
                Console.WriteLine("  [2] Buscar por Nombre");
                int opcion = LeerEntero("\n  Seleccione una opción: ");

                Producto? producto = null;

                if (opcion == 1)
                {
                    int id = LeerEntero("  Ingrese el ID del producto: ");
                    producto = sistema.ObtenerProductoPorId(id);
                }
                else if (opcion == 2)
                {
                    string nombre = LeerTexto("  Ingrese el nombre del producto: ");
                    var productos = sistema.ObtenerProductos().Where(e => e.Nombre.ToLower().Contains(nombre.ToLower())).ToList();

                    if (productos.Count > 1)
                    {
                        Console.WriteLine("\n  Se encontraron varios productos:");
                        foreach (var pro in productos)
                        {
                            Console.WriteLine($"  [{pro.Id}] {pro.Nombre}");
                        }
                        int id = LeerEntero("\n  Seleccione el ID específico: ");
                        producto = sistema.ObtenerProductoPorId(id);
                    }
                    else if (productos.Count == 1)
                    {
                        producto = productos[0];
                    }
                }

                if (producto != null)
                {
                    MostrarDetalleProducto(producto);
                }
                else
                {
                    Console.WriteLine("  No se encontró ningún empleado con esos criterios.");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write("  Seleccione una opción: ");
            }
        }

        private static void AgregarNuevoProducto(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR PRODUCTO ===");

            string sku = LeerTexto("SKU: ");
            string nombre = LeerTexto("Nombre del producto: ");
            string descripcion = LeerTexto("Descripción: ");
            decimal precio = LeerDecimal("Precio: ");
            int stock = LeerEntero("Stock inicial: ");

            var categoria = SeleccionarCategoriaProducto();
            if (categoria == null)
            {
                Console.WriteLine("❌ Categoría cancelada.");
                return;
            }

            var producto = new Producto
            {
                Sku = sku,
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock,
                Categoria = categoria.Value,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };

            sistema.AgregarProducto(producto);
            Console.WriteLine($"\n Producto {producto.Nombre} agregado con ID: {producto.Id}");
            Console.ReadKey();


        }

        static void MostrarDetalleProducto(Producto producto)
        {
            Console.Clear();
            Console.WriteLine($"\n  DETALLE DEL EMPLEADO - ID: {producto.Id}\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Sku: {producto.Sku}");
            Console.WriteLine($"  Nombre: {producto.Nombre}");
            Console.WriteLine($"  Descripcion: {producto.Descripcion}");
            Console.WriteLine($"  Precio : {producto.Precio}");
            Console.WriteLine($"  Stock: {producto.Stock}");
            Console.WriteLine($"  Categoria: {producto.Categoria}");
            Console.WriteLine($"  Fecha de Creación: {producto.FechaCreacion.ToShortTimeString()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static CategoriaProducto? SeleccionarCategoriaProducto()
        {
            Console.WriteLine("Seleccione una categoría de producto:");

            int i = 1;
            foreach (CategoriaProducto cat in Enum.GetValues(typeof(CategoriaProducto)))
            {
                Console.WriteLine($"[{i}] {cat}");
                i++;
            }
            Console.WriteLine("[0] Cancelar");

            while (true)
            {
                Console.Write("Opción: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return null;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= Enum.GetValues(typeof(CategoriaProducto)).Length)
                {
                    return (CategoriaProducto)(opcion - 1); // Restamos 1 porque enum empieza en 0
                }

                Console.WriteLine(" Opción inválida.");
            }
        }
        #endregion


        static void CargarDatosIniciales(SistemaInventario sistema)
        {
            //Agregar Tipos de Empleado
            var tipoAdmin = new TipoEmpleado{ Nombre = "Administrador", Descripcion = "Todos los Accesos"};
            var tipoAlmacen = new TipoEmpleado { Nombre = "Almacenero", Descripcion = "Gestion del Almacen" };
            var tipoVendedor = new TipoEmpleado { Nombre = "Vendedor", Descripcion = "Registro de Ventas" };
            

            sistema.AgregarTipoEmpleado(tipoAdmin);
            sistema.AgregarTipoEmpleado(tipoAlmacen);
            sistema.AgregarTipoEmpleado(tipoVendedor);

            var empleado1 = new Empleado { 
            
                Nombre = "Andre Antonio",
                TipoEmpleado = tipoAdmin,
                Estado = EstadoEmpleado.ACTIVO,
                FechaIngreso = DateTime.Now,
                Edad = 29,
                genero = Genero.MASCULINO,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
            
            };

            var empleado2 = new Empleado
            {

                Nombre = "Ronnie  Alarcon",
                TipoEmpleado = tipoVendedor,
                Estado = EstadoEmpleado.ACTIVO,
                FechaIngreso = DateTime.Now,
                Edad = 43,
                genero = Genero.MASCULINO,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,

            };

            var producto = new Producto
            {
                Sku = "34ffdsaas",
                Nombre = "Laptop ASUS ROCK 16",
                Descripcion = "Laptop con procesador core I9, 16gm Ram 1Tb SSD",
                Precio = 1500.45m,
                Stock = 4,
                Categoria = CategoriaProducto.LAPTOPS,
                FechaCreacion = DateTime.Parse(DateTime.Now.Date.ToString("dd/MM/yyyy"))
            };

            sistema.AgregarEmpleado(empleado1);
            sistema.AgregarEmpleado(empleado2);
            sistema.AgregarProducto(producto);

        }

        static string LeerTexto(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static int LeerEntero(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int valor))
            {
                return valor;
            }
            throw new FormatException("Debe ingresar un número válido.");
        }

        static decimal LeerDecimal(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal valor))
            {
                return (decimal) valor;
            }
            throw new FormatException("Debe ingresar un decimal valido.");
        }


    }
}
