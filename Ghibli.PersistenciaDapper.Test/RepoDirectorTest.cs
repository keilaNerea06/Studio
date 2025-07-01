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
        //llamamos a la funcion listar 
        var directors = _repoDirector.Listar();
        // Aseguramos de que haya guardado algo en directors
        Assert.NotEmpty(directors);
        //Pregunto por los directores que se dan de alta "
        Assert.Contains(directors, c => c.Nombre == "Hayao" && c.Apellido == "Miyazaki");
    }

    [Fact]
    public void AltaOK()
    {
        var guillermo = new Director()
        {
            idDirector = 122,
            Nombre = "Guillermo",
            Apellido = "Del Toro",
            nacionalidad = "Peru",
            FechaNacimiento = new DateTime(2011, 6, 10)
        };

        _repoDirector.Alta(guillermo);

        Assert.NotEqual(0, guillermo.idDirector);
    }

    [Fact]
    public void DetalleOK()
    {
        var hayao = _repoDirector.Detalle(1);
        Assert.NotNull(hayao);
        Assert.True(hayao.Nombre == "Hayao" && hayao.Apellido == "Miyazaki");
    }
    
    [Fact]
    public async Task AsyncTraerDirector()
    {
        //llamamos a la funcion listar 
        var directors =await _repoDirector.AsyncListar();
        // Aseguramos de que haya guardado algo en directors
        Assert.NotEmpty(directors);
        //Pregunto por los directores que se dan de alta "
        Assert.Contains(directors, c => c.Nombre == "Hayao" && c.Apellido == "Miyazaki");
    }

    [Fact]
    public async Task AsyncAltaOK()
    {
        var guillermo = new Director()
        {
            idDirector= 122,
            Nombre = "Guillermo",
            Apellido = "Del Toro",
            nacionalidad="Peru",
            FechaNacimiento= new DateTime(2011, 6, 10)
        };

        await _repoDirector.AsyncAlta(guillermo);

        Assert.NotEqual(0, guillermo.idDirector);
    }

    [Fact]
    public async Task AsyncDetalleOK()
    {
        var hayao = await _repoDirector.AsyncDetalle(1);
        Assert.NotNull(hayao);
        Assert.True(hayao.Nombre == "Hayao" && hayao.Apellido == "Miyazaki");
    }

}
