namespace Ghibli.Persistencia;

public interface IListado<T>
{
    IEnumerable<T> Listar();
}
