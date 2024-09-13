using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actores;

namespace Personajes
{
    class Personaje
    {
        public int idPersonaje { get; set; }
        public required string Nombre { get; set; }
        public int idPelicula { get; set; }
        public required ActorVoz Actor { get; set; }
    }
}