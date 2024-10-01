using System.Data;
using Dapper;
using Actores;
using Ghibli.Persistencia;
using Peli;
using estudio;

namespace Ghibli.PersistenciaDapper;

public class RepoStudio : RepoBase, IRepoStudio
{
    static readonly string _listadoPeliculas =
        @"SELECT id_pelicula AS IdPelicula, nombre as Nombre, fecha_estreno AS FechaEstreno, fecha_creacion AS FechaCreacion, Duracion, genero AS Genero, calificafion AS Calificacion, presupuesto AS Presupuesto, programa_estilo AS ProgramaEstilo, id_estudio AS idStudio
        FROM    peliculas";
    public RepoStudio(IDbConnection conexion)
        : base(conexion) { }

    public void Alta(Studio studio)
    {
        //throw new NotImplementedException();

        //Preparo los parametros del Stored Procedure
        var parametros = new DynamicParameters();
        
        parametros.Add("@unnombre", studio.Nombre);
        parametros.Add("@unfechaestreno", studio.FechaFundacion);
        parametros.Add("@unfechacreacion", studio.Ubicacion);
        parametros.Add("@unidpelicula", direction: ParameterDirection.Output);
    
        
        Conexion.Execute("agregarP", parametros);
       
        //Obtengo el valor de parametro de tipo salida
        studio.idStudio = parametros.Get<int>("@unidpelicula");
    }

    public Studio? Detalle(int idStudio)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Studio> Listar()
    {
        var peliculas = Conexion.Query<Studio>(_listadoPeliculas);
        return peliculas;
    }
}
