using Ghibli.Persistencia;
using estudio;
using Directores;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoStudioTest : TestBase
{
    readonly IRepoStudio _repoStudio;

    public RepoStudioTest() : base()
        => _repoStudio = new RepoStudio(Conexion);
    [Fact]
    public void TraerStudio()
    {
        var studios = _repoStudio.Listar();

        Assert.NotEmpty(studios);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(studios, c => c.Nombre == "Studio Ghibli" && c.idStudio == 1);
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

        var D = new Studio()
        {
            idStudio = 4,
            Nombre = "Pixar",
            Ubicacion = "USA",
            FechaFundacion = new DateTime(21, 1, 21),

        };

        _repoStudio.Alta(D);

        Assert.NotEqual(0, D.idStudio);
    }
    [Fact]
    public void DetalleOK()
    {
        var Ghibli = _repoStudio.Detalle(1);
        Assert.NotNull(Ghibli);
        Assert.True(Ghibli.Nombre == "Studio Ghibli" && Ghibli.idStudio == 1);
    }

    //asyncs
    
    [Fact]
    public async Task AsyncTraerStudio()
    {
        var studios =await _repoStudio.AsyncListar();

        Assert.NotEmpty(studios);
        //Pregunto por rubros que se dan de alta en "scripts/bd/MySQL/03 Inserts.sql"
        Assert.Contains(studios, c => c.Nombre == "Studio Ghibli" && c.idStudio == 1);
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
        
        var D = new Studio()
        {
            idStudio=4,
            Nombre = "Pixar",
            Ubicacion="USA",
            FechaFundacion= new DateTime(21,1,21),
            
        };

        await _repoStudio.AsyncAlta(D);

        Assert.NotEqual(0, D.idStudio);
    }
    [Fact]
    public async Task AsyncDetalleOK()
    {
        var Ghibli = await _repoStudio.AsyncDetalle(1);
        Assert.NotNull(Ghibli);
        Assert.True(Ghibli.Nombre == "Studio Ghibli" && Ghibli.idStudio == 1);
    }
}
