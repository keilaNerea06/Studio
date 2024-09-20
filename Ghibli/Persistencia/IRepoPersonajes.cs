using Personajes;
using Directores;

namespace Ghibli.Persistencia;

public interface IRepoPersonajes : IRepoAlta<Personaje>, IDetalle<Personaje, int>, IListado<Personaje>
{
    
}
