using System.Data;
using Dapper;
using Actores;
using Ghibli.Persistencia;
using System.Threading.Tasks;

namespace Ghibli.PersistenciaDapper;

public class RepoActor : RepoBase, IRepoActor
{
    static readonly string _listadoActores =
        @"SELECT id_actor AS IdActor, nombre, apellido
        FROM    Actor_voz";
    
    static readonly string _detalleActor = _listadoActores + @"
    WHERE id_actor = @idactor
    LIMIT 1";
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

        /*se ponen los metodos asincronicos en el excute*/
        Conexion.Execute("nuevoActor", parametros);

        //Obtengo el valor de parametro de tipo salida
        actor.IdActor = parametros.Get<int>("@unidactor");
    }


    /*Metodo asincronico para insertar*/
    public async Task AsyncAlta(ActorVoz actor)
    {
        //throw new NotImplementedException();

        //Preparo los parametros del Stored Procedure
        var parametros = new DynamicParameters();
        parametros.Add("@unnombre", actor.Nombre);
        parametros.Add("@unapellido", actor.Apellido);
        parametros.Add("@unidactor", direction: ParameterDirection.Output);

        /*se ponen los metodos asincronicos en el excute*/
        await Conexion.ExecuteAsync("nuevoActor", parametros);

        //Obtengo el valor de parametro de tipo salida
        actor.IdActor = parametros.Get<int>("@unidactor");
    }
    
    public ActorVoz? Detalle(int idActor)
    {
        var actor = Conexion.QueryFirst<ActorVoz>(
        _detalleActor,new { idActor = idActor });
        return actor;
    }

    public async Task<ActorVoz?> AsyncDetalle(int idActor)
    {
        var actor = await Conexion.QueryFirstAsync<ActorVoz>(
        _detalleActor, new { idActor = idActor });
        return actor;
    }


    async Task<IEnumerable<ActorVoz>> IListado<ActorVoz>.AsyncListar()
    {
    var actor = await Conexion.QueryAsync<ActorVoz>(_listadoActores);
        return actor;
    }

    IEnumerable<ActorVoz> IListado<ActorVoz>.Listar()
    {
        var actor = Conexion.Query<ActorVoz>(_listadoActores);
        return actor;
    }
}
