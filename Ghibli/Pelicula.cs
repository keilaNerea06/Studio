using Personajes;
using Directores;

namespace Peli;

public class Pelicula
{
    public int IdPelicula { get; set; }

    public required string Nombre { get; set; }

    public DateTime FechaEstreno { get; set; }

    public DateTime FechaCreacion { get; set; }

    public required string Duracion { get; set; }

    public required string Genero { get; set; }

    public required string Calificacion { get; set; }

    public int Presupuesto { get; set; }

    public required string ProgramaEstilo { get; set; }

    public int idStudio { get; set; }

    public required Director director { get; set; }

    public List<Personaje> Personajes { get; set; } = [];
}