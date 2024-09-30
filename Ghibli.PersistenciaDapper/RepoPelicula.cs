using System.Data;
using Dapper;
using Actores;
using Ghibli.Persistencia;
using Peli;

namespace Ghibli.PersistenciaDapper;

public class RepoPelicula : RepoBase, IRepoPelicula
{
    static readonly string _listadoActores =
        @"SELECT id_pelicula AS IdPelicula, nombre as Nombre, fecha_estreno AS FechaEstreno, fecha_creacion AS FechaCreacion, Duracion, genero AS Genero, calificafion AS Calificacion, presupuesto AS Presupuesto, programa_estilo AS ProgramaEstilo, id_estudio AS idStudio
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
        actor.IdActor = parametros.Get<int>("@unidactor");
    }

    public Pelicula? Detalle(int idPelicula)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ActorVoz> Listar()
    {
        var actores = Conexion.Query<ActorVoz>(_listadoActores);
        return actores;
    }
}
