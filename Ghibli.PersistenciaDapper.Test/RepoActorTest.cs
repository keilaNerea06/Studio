using Actores;
using Ghibli.Persistencia;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoActorTest : TestBase
{
    readonly IRepoActor _repoActor;

    public RepoActorTest() : base()
        => _repoActor = new RepoActor(Conexion);
    [Fact]
    public void TraerActor()
    {
        var actor = _repoActor.Listar();

        Assert.NotEmpty(actor);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(actor, c => c.Nombre == "Midred" && c.Apellido == "Barrera");
    }
    /*en vez de llamar a listar ponemos listar.async y llama a todos los metodos que son asincronicos*/

    [Fact]
    public async Task AsyncTraerActor()
    {
        var actor = await _repoActor.AsyncListar();

        Assert.NotEmpty(actor);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(actor, c => c.Nombre == "Midred" && c.Apellido == "Barrera");
    }

    [Fact]
    public void AltaOK()
    {
        var guillermo = new ActorVoz()
        {
            Nombre = "PEPE",
            Apellido = "Del Toro",
            IdActor = 122
        };

        _repoActor.Alta(guillermo);

        Assert.NotEqual(0, guillermo.IdActor);
    }

    [Fact]
    public async Task AsyncAltaOK()
    {
        var guillermo = new ActorVoz()
        {
            Nombre = "Guillermo",
            Apellido = "Del Toro",
            IdActor = 122
        };

        await _repoActor.AsyncAlta(guillermo);

        Assert.NotEqual(0, guillermo.IdActor);
    }

    [Fact]
    public void DetalleOK()
    {
        var Midred = _repoActor.Detalle(1);
        Assert.NotNull(Midred);
        Assert.True(Midred.Nombre == "Midred" && Midred.Apellido == "Barrera");
    }
    
    
    [Fact]
    public async Task AsyncDetalleOK()
    {
        var  Midred = await _repoActor.AsyncDetalle(1);
        Assert.NotNull(Midred);
        Assert.True( Midred.Nombre == "Midred" && Midred.Apellido == "Barrera" );
    }
    
}
