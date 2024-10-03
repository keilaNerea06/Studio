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

    [Fact]
    public void AltaOK()
    {
        var guillermo = new ActorVoz()
        {
            Nombre = "Guillermo",
            Apellido = "Franchella",
            IdActor= 122
        };

        _repoActor.Alta(guillermo);

        Assert.NotEqual(0, guillermo.IdActor);
    }
}
