using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Ghibli.PersistenciaDapper.Test;

public class TestBase
{
    protected readonly IDbConnection Conexion;
    public TestBase()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
            .Build();
        string cadena = config.GetConnectionString("MySQL")!;
        Conexion = new MySqlConnection(cadena);
    }
}
