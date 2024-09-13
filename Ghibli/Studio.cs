using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peli;

namespace estudio
{
    class Studio
    {
        public int idStudio { get; set; }
        public required string Nombre { get; set; }
        public DateTime FechaFundacion { get; set; }
        public required string Ubicacion { get; set; }
        public List<Pelicula> Peliculas { get; set; } = [];
    }
}