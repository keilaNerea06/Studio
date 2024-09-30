using Actores;
using Directores;
using Ghibli.Persistencia;
using Personajes;

namespace Ghibli.PersistenciaDapper.Test;

public class RepoPersonajeTest : TestBase
{
    readonly IRepoPersonajes _repoPersonaje;

    public RepoPersonajeTest() : base()
        => _repoPersonaje = new RepoPersonaje(Conexion);

    [Fact]
    public void AltaOK()
    {   var guill = new ActorVoz()
        {
            Nombre = "Guillermo",
            Apellido = "Franchella",
            IdActor= 122
        };
        var guillermo = new Personaje()
        {
            Nombre = "YO ya estoyyyyyy",
            idPelicula= 2,
            idPersonaje=1,
            Actor= guill
        };

        _repoPersonaje.Alta(guillermo);

        Assert.NotEqual(0, guillermo.idPersonaje);
    }
}
