using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampProject.Models
{
    public class Empleado
    {
        public string _nombre;
        public decimal _sueldo;

        public string Nombre 
        { 
            get {return _nombre;}
            set { _nombre = value;}
        }
        public decimal Sueldo
        {
            get{ return _sueldo;}
            set { _sueldo = value;}
        }

        public Empleado(string nombre, decimal sueldo)
        {
            this._nombre = nombre;
            this._sueldo = sueldo;
        }

        public void MostrarInfo()
        {
            Empleado empleado = new Empleado(nombre: "Ronnie", sueldo:1000);
        }
    }
}
