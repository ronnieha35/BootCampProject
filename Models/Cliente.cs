using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampProject.Models
{
    public class Cliente
    {
        private int _idCliente;
        private string _nombres;
        private string _apellidos;
        private string _razonSocial;
        private short _idTipoDocumentoIdentidad;
        private string _numeroDocumentoIdentidad;
        private string _direccionCliente;
        private string _numeroTelefono;
        private string _emailCliente;
        private bool _esPersonaNatural;
        private short _idEstado;
        private DateTime _fechaCreacion;
        private DateTime? _fechaModificacion;

        public int IdCliente
        {
            get { return _idCliente; } 
            set { _idCliente = value; }
        }

        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public string RazonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        public short IdTipoDocumentoIdentidad
        {
            get { return _idTipoDocumentoIdentidad; }
            set { _idTipoDocumentoIdentidad = value; }
        }

        public string NumeroDocumentoIdentidad
        {
            get { return _numeroDocumentoIdentidad;}
            set { _numeroDocumentoIdentidad= value; }
        }

        public string DireccionCliente
        {
            get { return _direccionCliente;}
            set { _direccionCliente = value; }
        }

        public string NumeroTelefono
        {
            get { return _numeroTelefono; } 
            set { _numeroTelefono = value; }
        }

        public string EmailCliente
        {
            get { return _emailCliente; }
            set {_emailCliente = value; }
        }

        public bool EsPersonaNatural
        {
            get { return _esPersonaNatural; }
            set { _esPersonaNatural = value; }
        }

        public short IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        public DateTime? FechaModificacion
        {
            get { return _fechaModificacion ; }
            set { _fechaModificacion = value; }
        }

        public Cliente(int idcliente, string nombres, string apellidos, string razonsocial, short idtipodocumentoidentidad, string numeroDocumentoIdentidad,
                       string direccioncliente, string numerotelefono, string emailcliente, bool espersonanatural, short idestado, DateTime fechacreacion, DateTime? fechamodificacion)
        {
            this._idCliente = idcliente;
            this._nombres = nombres;
            this._apellidos = apellidos;
            this._razonSocial = razonsocial;
            this._idTipoDocumentoIdentidad = idtipodocumentoidentidad;
            this._numeroDocumentoIdentidad= numeroDocumentoIdentidad;
            this._direccionCliente = direccioncliente;
            this._numeroTelefono = numerotelefono;
            this._emailCliente = emailcliente;
            this._esPersonaNatural = espersonanatural;
            this._idEstado = idestado;
            this._fechaCreacion = fechacreacion;
            this._fechaModificacion = fechamodificacion;
        }

    }
}
