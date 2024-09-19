using Actores;
using Ghibli.Persistencia;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoActorTest : TestBase
{
    readonly IRepoActor _repoActor;

    public RepoActorTest() : base()
        => _repoActor = new RepoActor(Conexion);

    [Fact]
    public void AltaOK()
    {
        var guillermo = new ActorVoz()
        {
            Nombre = "Guillermo",
            Apellido = "Franchella",
            IdActor= 562
        };

        _repoActor.Alta(guillermo);

        Assert.NotEqual(0, guillermo.IdActor);
    }
}
