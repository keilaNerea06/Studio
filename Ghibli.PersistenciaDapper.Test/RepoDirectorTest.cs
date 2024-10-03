using Directores;
using Ghibli.Persistencia;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoDirectorTest : TestBase
{
    readonly IRepoDirector _repoDirector;

    public RepoDirectorTest() : base()
        => _repoDirector = new RepoDirector(Conexion);
      [Fact]
    public void TraerDirector()
    {
        var directors = _repoDirector.Listar();

        Assert.NotEmpty(directors);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(directors, c => c.Nombre == "Hayao" && c.Apellido == "Miyazaki");
    }

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
