using System.Security.Cryptography;

namespace SolidPrincipalesPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Crear las implementaciones concretas

            var repositorui = new RepositorioProductos();
            var notificador = new EmailNotificacodr();
            var Validar = new InventarioValidador();

            //inyectar dependencias al gestor
            var gestorinventario = new GestorInventario(repositorui, notificador, Validar);

            var producto1 = new Producto(id: 1, nombre: "laptop", precio: 1500m, stock: 10);
            var producto2 = new Producto(id: 2, nombre: "teclado", precio: 1500m, stock: 10);
            var producto3 = new Producto(id: 3, nombre: "monitor", precio: 1500m, stock: 10);

            //agregar producto a repositoryi
            repositorui.
        }

        //Principio de Responsabilidad Unica
        //Clase solo representa un producto
        public class Producto
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }

            public Producto(int id, string nombre, decimal precio, int stock)
            {
                ID = id;
                Nombre = nombre;
                Precio = precio;
                Stock = stock;
            }
        }

        //Se cumple el principio de Abierto /Cerrado (o)
        //Interfaces para extender funcionalidad sin la necesidad de modificacr codigo existente
        public interface IRepositoryProducto
        {
            void AgregarProducto(Producto producto);
            void ActualizadProducto(Producto producto);
            Producto ObtenerProducto(int id);
            void EliminarProducto(int id);  

        }

        //Implementacion concreta del repositorio
        public class RepositorioProductos : IRepositoryProducto
        {
            private readonly List<Producto> _productos = new List<Producto>();
            public void EliminarProducto(int id)
            {
                throw new NotImplementedException();
            }

            void IRepositoryProducto.ActualizadProducto(Producto producto)
            {
                if (producto != null)
                {
                    var productoexistente = IRepositoryProducto.ObtenerProducto(producto.ID);
                }
                
            }

            void IRepositoryProducto.AgregarProducto(Producto producto)
            {
                _productos.Add(producto);
                Console.WriteLine($"Agregando Producto con nombre: {producto.Nombre}");
            }

            Producto? IRepositoryProducto.ObtenerProducto(int id)
            {
                return _productos.Find(x => x.ID == id);

            }
        }

        //Principio de Segregacion interfaces (i)
        public interface INotificador
        {
            void Notificar(string mensaje);
        }
        public interface IInventarioValidado
        {
            bool ValidarStoc(Producto producto, int stock);
        }

        public class EmailNotificacodr : INotificador
        {
            public void Notificar(string mensaje)
            {
                Console.WriteLine($"Notificacion por email : {mensaje}");
            }
        }

        public class InventarioValidador : IInventarioValidado
        {
            bool IInventarioValidado.ValidarStoc(Producto producto, int stock)
            {
               return producto.Stock >= stock;
            }
        }

        //Principio de inversdion de dependencias (D)
        //Debemos depender de abstracciones y no de implementaciones
        public class GestorInventario
        {
            private readonly IRepositoryProducto _repositoryProducto;
            private readonly INotificador _notificador;
            private readonly IInventarioValidado _inventarioValidador;
            
            public GestorInventario(IRepositoryProducto repositorioproductos, INotificador notificador, IInventarioValidado inventarioValidado)//Propiedad de la clase
            {
                _repositoryProducto = repositorioproductos;
                _notificador = notificador;
                _inventarioValidador = inventarioValidado;
            }

            //Principio de sustitucion de Lisko (L)
            //Cualquier implementacion de Irepositoryproductos va funciona aca
            public void ReducirStick(int productoid, int cantidad)
            {
                var producto = _repositoryProducto.ObtenerProducto(productoid);

                if (producto == null)
                {
                    _notificador.Notificar($"Producto no encontrado");

                }

                if (_inventarioValidador.ValidarStoc(producto, cantidad))
                {
                    producto.Stock -= cantidad;
                    _repositoryProducto.AgregarProducto(producto);
                    _notificador.Notificar($"stock agreegado : {producto.Stock}");
                }
                else
                {
                    _notificador.Notificar($"Stock Insuficiente {producto.Nombre}");
                }
            }

            public void ListarTodosLosProductos()
            {
                Console.WriteLine("Lista de productos");
                var products = _repositoryProducto.l;

                foreach (var product in products)
                {
                    Console.WriteLine($"Nombre : {product.Nombre}");
                }
            }
        }
    }
}
