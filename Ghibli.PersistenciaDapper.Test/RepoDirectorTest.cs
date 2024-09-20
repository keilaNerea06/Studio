using Directores;
using Ghibli.Persistencia;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoDirectorTest : TestBase
{
    readonly IRepoDirector _repoDirector;

    public RepoDirectorTest() : base()
        => _repoDirector = new RepoDirector(Conexion);

    [Fact]
    public void AltaOK()
    {
        var guillermo = new Director()
        {
            idDirector= 122,
            Nombre = "Guillermo",
            Apellido = "Franchella",
            nacionalidad="Peru",
            FechaNacimiento= new DateTime(2011, 6, 10)
        };

        _repoDirector.Alta(guillermo);

        Assert.NotEqual(0, guillermo.idDirector);
    }
}
