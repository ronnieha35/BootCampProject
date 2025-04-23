namespace InvetaryProject
{
    public class SistemaInventario
    {
        private List<TipoEmpleado> _tipoEmpleados = new List<TipoEmpleado>();
        private List<Empleado> _empleados = new List<Empleado>();
        private List<Producto> _productos = new List<Producto>();
        private List<MovimientoStock> _movimientos = new List<MovimientoStock>();

        #region Movimiento Stock
        public void AgregarMovimientoStock(MovimientoStock movimientoStock)
        {
            _movimientos.Add(movimientoStock);
        }

        public List<MovimientoStock> ObtenerMovimientos()
        {
            return _movimientos.ToList();
        }
        #endregion
        #region Empleados
        //Metodo para agregar un tipo empleado
        public void AgregarTipoEmpleado(TipoEmpleado tipoEmpleado)
        {
            _tipoEmpleados.Add(tipoEmpleado);
        }

        //Lista Tipos de Empleados
        public List<TipoEmpleado> ObtenerTipoEmpleado()
        {
            return _tipoEmpleados.ToList();
        }

        //Obtener tipo empleado por Id
        public TipoEmpleado? ObtenerTipoEmpleadoPorId(int id)
        {
            return _tipoEmpleados.FirstOrDefault(x => x.Id == id);
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            _empleados.Add(empleado);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return _empleados.ToList();
        }

        public Empleado? ObtenerEmpleadoPorId(int id)
        {
            return _empleados.FirstOrDefault(x => x.Id == id);
        }
        #endregion
        #region Producto
        public void AgregarProducto(Producto producto)
        {
            _productos.Add(producto);
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            return _productos.FirstOrDefault(x => x.Id == id);
        }

        public List<Producto> ObtenerProductos()
        {
            return _productos.ToList();
        }
        #endregion




    }
}