using Actores;
using Ghibli.Persistencia;
using estudio;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoStudioTest : TestBase
{
    readonly IRepoStudio _repoStudio;

    public RepoStudioTest() : base()
        => _repoStudio = new RepoStudio(Conexion);

    [Fact]
    public void AltaOK()
    {
        var D = new Studio()
        {
            idStudio=2,
            Nombre = "Guillermo",
            Ubicacion="nose"
        };

        _repoStudio.Alta(D);

        Assert.NotEqual(0, D.idStudio);
    }
}
