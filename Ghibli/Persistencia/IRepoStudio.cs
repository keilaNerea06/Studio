using estudio;
using Peli;
using Personajes;

namespace Ghibli.Persistencia;

public interface IRepoStudio : IRepoAlta<Studio>, IDetalle<Studio, int>, IListado<Studio>
{
    
}
