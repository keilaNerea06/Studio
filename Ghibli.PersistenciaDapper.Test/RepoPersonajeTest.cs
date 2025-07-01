using Actores;
using Ghibli.Persistencia;
using Personajes;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoPersonajeTest : TestBase
{
    readonly IRepoPersonajes _repoPersonaje;

    public RepoPersonajeTest() : base()
        => _repoPersonaje = new RepoPersonaje(Conexion);

    [Fact]
    public void TraerPersonaje()
    {
        var personajes = _repoPersonaje.Listar();

        Assert.NotEmpty(personajes);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(personajes, c => c.Nombre == "Príncipe Arren / Lebannen" && c.idPersonaje == 1);
    }
    [Fact]
    public void AltaOK()
    {
        var guill = new ActorVoz()
        {
            Nombre = "Guillermo",
            Apellido = "Franchella",
            IdActor = 122
        };
        var guillermo = new Personaje()
        {
            Nombre = "Hachiko",
            idPelicula = 2,
            idPersonaje = 1,
            Actor = guill
        };

        _repoPersonaje.Alta(guillermo);

        Assert.NotEqual(0, guillermo.idPersonaje);
    }

    [Fact]
    public void DetalleOK()
    {
        var gavilan = _repoPersonaje.Detalle(3);
        Assert.NotNull(gavilan);
        Assert.True(gavilan.Nombre == "Gavilán" && gavilan.idPelicula == 2);
    }

    //async test
    
    [Fact]
    public async Task AsyncTraerPersonaje()
    {
        var personajes =await _repoPersonaje.AsyncListar();

        Assert.NotEmpty(personajes);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(personajes, c => c.Nombre == "Príncipe Arren / Lebannen" && c.idPersonaje == 1);
    }
    [Fact]
    public async Task AsyncAltaOK()
    {   var guill = new ActorVoz()
        {
            Nombre = "Guillermo",
            Apellido = "Franchella",
            IdActor= 122
        };
        var guillermo = new Personaje()
        {
            Nombre = "Hachiko",
            idPelicula= 2,
            idPersonaje=1,
            Actor= guill
        };

        await _repoPersonaje.AsyncAlta(guillermo);

        Assert.NotEqual(0, guillermo.idPersonaje);
    }

    [Fact]
    public async Task AsyncDetalleOK()
    {
        var gavilan =await _repoPersonaje.AsyncDetalle(3);
        Assert.NotNull(gavilan);
        Assert.True(gavilan.Nombre == "Gavilán" && gavilan.idPelicula == 2);
    }
}
