using Personajes;

namespace Ghibli.Persistencia;

public interface IRepoPersonajes : IRepoAlta<Personaje>, IDetalle<Personaje, int>, IListado<Personaje>
{
    
}
