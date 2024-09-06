using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personajes;
using Directores;

namespace Peli
{
    class Pelicula
    {
        int idPelicula;
        string Nombre;
        DateTime FechaEstreno;
        DateTime FechaCreacion;
        Double Duracion;
        string Genero;
        int Calificacion;
        int Presupuesto;
        string ProgramaEstilo;
        Director director;
        int idStudio;
        List<Personaje> personajes;
    }
}