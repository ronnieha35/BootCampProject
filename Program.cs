using BootCampProject.Models;

namespace BootCampProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Estado> estados = new List<Estado>()
            {
                new Estado(idestado: 1, descripcionestado: "ACTIVO", fechacreacion: DateTime.Parse("16-04-2025"), fechamodificacion: null),
                new Estado(idestado: 1, descripcionestado: "INACTIVO", fechacreacion: DateTime.Parse("16-04-2025"), fechamodificacion: null)
            };

            List<TipoDocumentoIdentidad> tipoDocumentosIdentidad = new List<TipoDocumentoIdentidad>()
            {
                new TipoDocumentoIdentidad(idtipodocumentoidentidad: 1, descripcion: "DNI", codigodocumentoidentidad:'1', idestado:1, fechacreacion: DateTime.Parse("16-04-2025"), fechamodificacion: null),
                new TipoDocumentoIdentidad(idtipodocumentoidentidad: 1, descripcion: "RUC", codigodocumentoidentidad:'6', idestado:1, fechacreacion: DateTime.Parse("16-04-2025"), fechamodificacion: null)
            };


            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(idcliente:1, nombres:"Ronnie Alarcon", apellidos:"Alarcon Morales", razonsocial: "", idtipodocumentoidentidad:1, numeroDocumentoIdentidad:"40801644", direccioncliente:"",numerotelefono:"",
                            emailcliente:"ronniealarcon@gmail.com",espersonanatural:true,idestado:1,fechacreacion:DateTime.Parse("16-04-2025"), fechamodificacion:null),
                 new Cliente(idcliente:2, nombres:"", apellidos:"", razonsocial:"Motrisa S.A.C", idtipodocumentoidentidad:6, numeroDocumentoIdentidad:"2054252321", direccioncliente:"",numerotelefono:"",
                            emailcliente:"motrisa@gmail.com",espersonanatural:false,idestado:1,fechacreacion:DateTime.Parse("16-04-2025"), fechamodificacion:null),
            };


            Console.WriteLine("==== LISTA DE ESTADOS ====");
            foreach (var estado in estados)
            {
                Console.WriteLine($"ID: {estado.IdEstado}, Descripción: {estado.DescripcionEstado}, Fecha Creación: {estado.FechaCreacion:dd/MM/yyyy}, Fecha Modificación: {(estado.FechaModificacion.HasValue ? estado.FechaModificacion.Value.ToString("dd/MM/yyyy") : "N/A")}");
            }


            Console.WriteLine("\n==== LISTA DE TIPOS DE DOCUMENTO ====");
            foreach (var tipo in tipoDocumentosIdentidad)
            {
                Console.WriteLine($"ID: {tipo.IdTipoDocumentoIdentidad}, Descripción: {tipo.Descripcion}, Código: {tipo.CodigoDocumentoIdentidad}, Estado ID: {tipo.IdEstado}, Fecha Creación: {tipo.FechaCreacion:dd/MM/yyyy}, Fecha Modificación: {(tipo.FechaModificacion.HasValue ? tipo.FechaModificacion.Value.ToString("dd/MM/yyyy") : "N/A")}");
            }

            Console.WriteLine("\n==== LISTA DE CLIENTES ====");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.IdCliente}, Nombre: {cliente.Nombres} {cliente.Apellidos}, Razon Social: {cliente.RazonSocial}, Documento: {cliente.NumeroDocumentoIdentidad}, Email: {cliente.EmailCliente}, Persona Natural: {(cliente.EsPersonaNatural ? "Sí" : "No")}, Estado ID: {cliente.IdEstado}, Fecha Creación: {cliente.FechaCreacion:dd/MM/yyyy}, Fecha Modificación: {(cliente.FechaModificacion.HasValue ? cliente.FechaModificacion.Value.ToString("dd/MM/yyyy") : "N/A")}");
            }
        }

        
    }
}
