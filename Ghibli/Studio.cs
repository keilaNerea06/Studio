using Peli;

namespace estudio;

public class Studio
{
    public int idStudio { get; set; }
    public required string Nombre { get; set; }
    public DateTime FechaFundacion { get; set; }
    public required string Ubicacion { get; set; }
    public List<Pelicula> Peliculas { get; set; } = [];
}