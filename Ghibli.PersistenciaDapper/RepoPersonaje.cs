using System.Data;
using Dapper;
using Actores;
using Ghibli.Persistencia;
using Personajes;

namespace Ghibli.PersistenciaDapper;

public class RepoPersonaje : RepoBase, IRepoPersonajes
{
    static readonly string _listadoPersonajes =
        @"SELECT id_personaje AS idPersonaje, Nombre, id_pelicula AS idPelicula
        FROM    Personajes";
    public RepoPersonaje(IDbConnection conexion)
        : base(conexion) { }

    public void Alta(Personaje personaje)
    {
        //throw new NotImplementedException();

        //Preparo los parametros del Stored Procedure
        var parametros = new DynamicParameters();
        parametros.Add("@unidpelicula",personaje.idPelicula);
        parametros.Add("@unnombre", personaje.Nombre);
        //parametros.Add("actor", personaje.Actor);
        parametros.Add("@unidpersonaje", direction: ParameterDirection.Output);
        
        
        Conexion.Execute("agregarPer", parametros);
       
        //Obtengo el valor de parametro de tipo salida
        personaje.idPersonaje = parametros.Get<int>("@unidactor");
    }

    public Personaje? Detalle(int idPersonaje)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Personaje> Listar()
    {
        var personajes = Conexion.Query<Personaje>(_listadoPersonajes);
        return personajes;
    }
}