using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampProject.Models
{
    public class Estado
    {
        public short _idEstado;
        public string _descripcionEstado;
        public DateTime _fechaCreacion;
        public DateTime? _fechaModificacion;

        public short IdEstado
        {
            get { return _idEstado; } 
            set { _idEstado = value; }
        }

        public string DescripcionEstado
        {
            get { return _descripcionEstado; }
            set { _descripcionEstado = value; }
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

        public Estado(short idestado, string descripcionestado, DateTime fechacreacion , DateTime? fechamodificacion)
        {
            this._idEstado = idestado;
            this._descripcionEstado = descripcionestado;
            this._fechaCreacion = fechacreacion;
            this._fechaModificacion = fechamodificacion;
        }
    }
}
