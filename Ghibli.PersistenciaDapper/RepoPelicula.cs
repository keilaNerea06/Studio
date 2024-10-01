using System.Data;
using Dapper;
using Actores;
using Ghibli.Persistencia;
using Peli;

namespace Ghibli.PersistenciaDapper;

public class RepoPelicula : RepoBase, IRepoPelicula
{
    static readonly string _listadoPeliculas =
        @"SELECT id_pelicula AS IdPelicula, nombre as Nombre, fecha_estreno AS FechaEstreno, fecha_creacion AS FechaCreacion, Duracion, genero AS Genero, calificafion AS Calificacion, presupuesto AS Presupuesto, programa_estilo AS ProgramaEstilo, id_estudio AS idStudio
        FROM    peliculas";
    public RepoPelicula(IDbConnection conexion)
        : base(conexion) { }

    public void Alta(Pelicula pelicula)
    {
        //throw new NotImplementedException();

        //Preparo los parametros del Stored Procedure
        var parametros = new DynamicParameters();
        parametros.Add("@unidestudio", pelicula.idStudio);
        parametros.Add("@unidirector", pelicula.director.idDirector);
        parametros.Add("@unnombre", pelicula.Nombre);
        parametros.Add("@unfechaestreno", pelicula.FechaEstreno);
        parametros.Add("@unfechacreacion", pelicula.FechaCreacion);
        parametros.Add("@unDuracion", pelicula.Duracion);
        parametros.Add("@ungenero",pelicula.Genero);
        parametros.Add("@unpresupuesto",pelicula.Presupuesto);
        parametros.Add("@uncalificacion",pelicula.Calificacion);
        parametros.Add("@unprogramastilo",pelicula.ProgramaEstilo);
        parametros.Add("@unidpelicula", direction: ParameterDirection.Output);
    
        
        Conexion.Execute("agregarP", parametros);
       
        //Obtengo el valor de parametro de tipo salida
        pelicula.IdPelicula = parametros.Get<int>("@unidpelicula");
    }

    public Pelicula? Detalle(int idPelicula)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pelicula> Listar()
    {
        var peliculas = Conexion.Query<Pelicula>(_listadoPeliculas);
        return peliculas;
    }
}
