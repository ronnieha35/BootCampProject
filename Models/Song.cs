using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampProject.Models
{
    public class Song
    {
        private string _name;
        private string _artist;
        private string _genre;
        private string _albumname;
        private int _durationseconds;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Song(string name, string artist, string genre, string albumname, int durationseconds)
        { 
            this._name = name;
            this._artist = artist;
            this._genre = genre;
            this._albumname = albumname;
            this._durationseconds = durationseconds;

        }

        public Song(string name, string artust, string albumname, int durationseconds)
        {
            this._name=name;
            this._artist=artust;
            this._albumname=albumname;
            this._durationseconds = durationseconds;


        }

        string mostrarNombreCancion(string nombre)
        {
            return _name + " " + nombre;
        }
    }
}
