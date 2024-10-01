using Directores;
using Ghibli.Persistencia;
using Peli;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoPeliculaTest : TestBase
{
    readonly IRepoPelicula _repoPelicula; 

    public RepoPeliculaTest() : base()
        => _repoPelicula = new RepoPelicula(Conexion);

    [Fact]
    public void AltaOK()
    {
        var guillermo = new Director()
        {
            idDirector= 8,
            Nombre = "Guillermo",
            Apellido = "Franchella",
            nacionalidad="Peru",
            FechaNacimiento= new DateTime(2011, 6, 10)
        };

        var nino = new Pelicula()
        {
            IdPelicula= 122,
            Nombre = "Niño y la Garza",
            idStudio = 1,
            FechaEstreno = new DateTime(2011, 6, 10),
            FechaCreacion = new DateTime(2011, 6, 10),
            Duracion= 2.0,
            Genero= "Animacion",
            Calificacion= 9,
            Presupuesto= 110002,
            ProgramaEstilo= "usaweew",
            director= guillermo
        };

        _repoPelicula.Alta(nino);

        Assert.NotEqual(0, nino.IdPelicula);
    }
}
