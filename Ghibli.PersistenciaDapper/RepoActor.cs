using System.Data;
using Dapper;
using Actores;
using Ghibli.Persistencia;

namespace Ghibli.PersistenciaDapper;

public class RepoActor : RepoBase, IRepoActor
{
    static readonly string _listadoActores =
        @"SELECT id_actor AS IdActor, nombre, apellido
        FROM    Actor_voz";
    public RepoActor(IDbConnection conexion)
        : base(conexion) { }

    public void Alta(ActorVoz actor)
    {
        //throw new NotImplementedException();

        //Preparo los parametros del Stored Procedure
        var parametros = new DynamicParameters();
        parametros.Add("@unnombre", actor.Nombre);
        parametros.Add("@unapellido", actor.Apellido);
        parametros.Add("@unidactor", direction: ParameterDirection.Output);
    
        
        Conexion.Execute("nuevoActor", parametros);
       
        //Obtengo el valor de parametro de tipo salida
        actor.IdActor = parametros.Get<byte>("@unidactor");
    }

    public ActorVoz? Detalle(int idActor)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ActorVoz> Listar()
    {
        var actores = Conexion.Query<ActorVoz>(_listadoActores);
        return actores;
    }
}
