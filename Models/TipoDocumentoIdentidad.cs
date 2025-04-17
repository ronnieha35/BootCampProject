using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampProject.Models
{
    public class TipoDocumentoIdentidad
    {
        public short _idTipoDocumentoIdentidad;
        public string _descripcion;
        public char _codigoDocumentoIdentidad;
        public short _idEstado;
        public DateTime _fechaCreacion;
        public DateTime? _fechaModificacion;

        public short IdTipoDocumentoIdentidad
        {
            get { return _idTipoDocumentoIdentidad; }
            set { _idTipoDocumentoIdentidad = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public char CodigoDocumentoIdentidad
        {
            get { return _codigoDocumentoIdentidad; }
            set { _codigoDocumentoIdentidad = value; }
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
            get { return _fechaModificacion; }
            set { _fechaModificacion = value; }
        }

        public TipoDocumentoIdentidad(short idtipodocumentoidentidad, string descripcion, char codigodocumentoidentidad, short idestado, DateTime fechacreacion, DateTime? fechamodificacion)
        {
            this._idTipoDocumentoIdentidad = idtipodocumentoidentidad;
            this._descripcion = descripcion;
            this._codigoDocumentoIdentidad = codigodocumentoidentidad;
            this._idEstado = idestado;
            this._fechaCreacion = fechacreacion;
            this._fechaModificacion = fechamodificacion;

        }

    }
}
