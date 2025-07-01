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

    static readonly string _detallePersonajes = _listadoPersonajes + @"
    where id_personaje = @idPersonaje
    limit 1";

    public RepoPersonaje(IDbConnection conexion)
        : base(conexion) { }

    public void Alta(Personaje personaje)
    {
        //throw new NotImplementedException();

        //Preparo los parametros del Stored Procedure
        var parametros = new DynamicParameters();
        parametros.Add("@unidpersonaje", direction: ParameterDirection.Output);
        parametros.Add("@unidpelicula", personaje.idPelicula);
        parametros.Add("@unnombre", personaje.Nombre);
        var parametrosR = new DynamicParameters();
        parametrosR.Add("@actor", personaje.Actor.IdActor);
        parametrosR.Add("@personaje", personaje.idPersonaje);
        //parametros.Add("actor", personaje.Actor);

        Conexion.Execute("agregarPer", parametros);
        Conexion.Execute("asignarAP", parametrosR);
        //Obtengo el valor de parametro de tipo salida
        personaje.idPersonaje = parametros.Get<int>("@unidpersonaje");
    }

    public async Task AsyncAlta(Personaje personaje)
    {
        //Preparo los parametros del Stored Procedure
        var parametros = new DynamicParameters();
        parametros.Add("@unidpersonaje", direction: ParameterDirection.Output);
        parametros.Add("@unidpelicula", personaje.idPelicula);
        parametros.Add("@unnombre", personaje.Nombre);
        var parametrosR = new DynamicParameters();
        parametrosR.Add("@actor", personaje.Actor.IdActor);
        parametrosR.Add("@personaje", personaje.idPersonaje);
        //parametros.Add("actor", personaje.Actor);

        await Conexion.ExecuteAsync("agregarPer", parametros);
        await Conexion.ExecuteAsync("asignarAP", parametrosR);
        //Obtengo el valor de parametro de tipo salida
        personaje.idPersonaje = parametros.Get<int>("@unidpersonaje");
    }

    public Personaje? Detalle(int idPersonaje)
    {
        var personaje = Conexion.QueryFirst<Personaje>(
            _detallePersonajes,
            new { idPersonaje = idPersonaje });
        return personaje;
    }

    public async Task<Personaje?> AsyncDetalle(int idPersonaje)
    {
        var personaje = await Conexion.QueryFirstAsync<Personaje>(
            _detallePersonajes,
            new { idPersonaje = idPersonaje });
        return personaje;
    }

    public IEnumerable<Personaje> Listar()
    {
        var personajes = Conexion.Query<Personaje>(_listadoPersonajes);
        return personajes;
    }
    
    public async Task<IEnumerable<Personaje>> AsyncListar()
    {
        var personajes = await Conexion.QueryAsync<Personaje>(_listadoPersonajes);
        return personajes;
    }
}