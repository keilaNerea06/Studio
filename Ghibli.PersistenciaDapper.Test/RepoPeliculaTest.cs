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
    public void TraerPelicula()
    {
        var peliculas = _repoPelicula.Listar();

        Assert.NotEmpty(peliculas);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(peliculas, c => c.Nombre == "Cuentos de terramar" && c.IdPelicula == 2);
    }

    [Fact]
    public void AltaOK()
    {
        var guillermo = new Director()
        {
            idDirector = 8,
            Nombre = "Guillermo",
            Apellido = "Franchella",
            nacionalidad = "Peru",
            FechaNacimiento = new DateTime(2011, 6, 10)
        };

        var nino = new Pelicula()
        {
            IdPelicula = 122,
            Nombre = "Niño y la Garza",
            idStudio = 1,
            FechaEstreno = new DateTime(2011, 6, 10),
            FechaCreacion = new DateTime(2011, 6, 10),
            Duracion = "2.h",
            Genero = "Animacion",
            Calificacion = "9.2",
            Presupuesto = 110002,
            ProgramaEstilo = "usaweew",
            director = guillermo
        };

        _repoPelicula.Alta(nino);

        Assert.NotEqual(0, nino.IdPelicula);
    }

    [Fact]
    public void DetalleOK()
    {
        var totoro = _repoPelicula.Detalle(3);
        Assert.NotNull(totoro);
        Assert.True(totoro.Nombre == "Totoro" && totoro.IdPelicula == 3);
    }
    //Async de test
        
    [Fact]
    public async Task AsyncTraerPelicula()
    {
        var peliculas = await _repoPelicula.AsyncListar();

        Assert.NotEmpty(peliculas);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(peliculas, c => c.Nombre == "Cuentos de terramar" && c.IdPelicula == 2);
    }

    [Fact]
    public async Task AsyncAltaOK()
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
            Duracion= "2.h",
            Genero= "Animacion",
            Calificacion= "9.2",
            Presupuesto= 110002,
            ProgramaEstilo= "usaweew",
            director= guillermo
        };

        await _repoPelicula.AsyncAlta(nino);

        Assert.NotEqual(0, nino.IdPelicula);
    }

    [Fact]
    public async Task AsyncDetalleOK()
    {
        var  totoro =await _repoPelicula.AsyncDetalle(3);
        Assert.NotNull(totoro);
        Assert.True( totoro.Nombre == "Totoro" && totoro.IdPelicula == 3 );
    }
}
