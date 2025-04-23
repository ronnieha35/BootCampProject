namespace InvetaryProject
{
    public class MovimientoStock
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public Producto Producto { get; set; }
        public Empleado Empleado { get; set; }
        public int Cantidad { get; set; }
        public TipMovimiento tipoMovimiento { get; set; }
        public DateTime FechaCreacion { get; set; }    


        public MovimientoStock()
        {
            Id = _nextId++;
        }
    }
}