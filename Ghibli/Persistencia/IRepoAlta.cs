namespace Ghibli.Persistencia;

public interface IRepoAlta<T>
{
    void Alta(T elemento);
    
/*No se puede declarar un metodo que devulva task void, ya que void es un metodo, solo se usa en metodos asincronicos*/
    Task AsyncAlta(T elemento);
}