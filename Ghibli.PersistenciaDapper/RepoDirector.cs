using System.Data;
using Dapper;
using Ghibli.Persistencia;
using Directores;

namespace Ghibli.PersistenciaDapper;

public class RepoDirector : RepoBase, IRepoDirector
{
    static readonly string _listadoDirectores =
        @"SELECT id_Director AS idDirector, nombre, Apellido, nacionalidad, Fecha_nacimiento as FechaNacimiento
        FROM    Director";
    public RepoDirector(IDbConnection conexion)
        : base(conexion) { }

    public void Alta(Director director)
    {
        //throw new NotImplementedException();

        //Preparo los parametros del Stored Procedure
        var parametros = new DynamicParameters();
        parametros.Add("@unidDirector", direction: ParameterDirection.Output);
        parametros.Add("@unnombre", director.Nombre);
        parametros.Add("@unapellido", director.Apellido);
        parametros.Add("@unanacionalidad", director.nacionalidad);
        parametros.Add("@unaFecha", director.FechaNacimiento);
        
        Conexion.Execute("directorAG", parametros);
       
        //Obtengo el valor de parametro de tipo salida
        director.idDirector = parametros.Get<int>("@unidDirector");
    }

    public Director? Detalle(int idDirector)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Director> Listar()
    {
        var Directores = Conexion.Query<Director>(_listadoDirectores);
        return Directores;
    }
}
