using System.Numerics;

namespace Ghibli.Persistencia;

public interface IDetalle<T, IS> where IS : IBinaryNumber<IS>
{
    T? Detalle(IS indiceSimple);
    /*Aca se le pone los verbos Task en todos las Interfaces*/
    Task<T?> AsyncDetalle(IS indiceSimple);
}

