namespace Ghibli.Persistencia;

public interface IListado<T>
{
    IEnumerable<T> Listar();
    /*Todo proceso de lista <t> se encierra en otros <>*/
    Task<IEnumerable<T>> AsyncListar();
}
