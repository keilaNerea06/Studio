using Actores;
using Ghibli.Persistencia;
using estudio;
using Peli;
using Directores;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoStudioTest : TestBase
{
    readonly IRepoStudio _repoStudio;

    public RepoStudioTest() : base()
        => _repoStudio = new RepoStudio(Conexion);

    [Fact]
    public void AltaOK()
    {
        var guillermo = new Director()
        {
            idDirector= 8,
            Nombre = "Guillermo",
            Apellido = "Franchella",
            nacionalidad="Peru",
            FechaNacimiento= new DateTime(2011, 6, 10)
            
        };
        var P = new Pelicula()
        {
            Nombre= "Wall-e",
            Calificacion=9,
            idStudio=4,
            IdPelicula=1,
            Genero= "ANIMACION",
            ProgramaEstilo=" ",
            director = guillermo
        };
        var D = new Studio()
        {
            idStudio=4,
            Nombre = "Pixar",
            Ubicacion="USA",
            FechaFundacion= new DateTime(21,1,21),
            
        };

        _repoStudio.Alta(D);

        Assert.NotEqual(0, D.idStudio);
    }
}
