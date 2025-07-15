using Ghibli.PersistenciaDapper;
using Ghibli;
using System.Data;
using MySqlConnector;
using Ghibli.Persistencia;
using Scalar.AspNetCore;
using Directores;

var builder = WebApplication.CreateBuilder(args);
//inicializamos las interfaqces qu7e vamos a utilizar en el code

//  Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MySQL");


//buscamos del app seting la conexxion con la bd

//  Registrando IDbConnection para que se inyecte como dependencia
//  Cada vez que se inyecte, se creará una nueva instancia con la cadena de conexión
builder.Services.AddScoped<IDbConnection>(sp => new MySqlConnection(connectionString));

//Cada vez que necesite la interfaz, se va a instanciar automaticamente AdoDapper y se va a pasar al metodo de la API, intenciamos la inter
builder.Services.AddScoped<IRepoActor, RepoActor>();
builder.Services.AddScoped<IRepoDirector, RepoDirector>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}

// Trae una lista de todos los directores
app.MapGet("/Director", async (IRepoDirector directores) =>
    await directores.AsyncListar);

app.MapPost("/Director", async (Director nuevo, IRepoDirector directores) =>
{
    await directores.AsyncAlta(nuevo);

    return Results.Created($"/Director/{nuevo.idDirector}", nuevo);
});

//para que haya un put o patch tiene que existir un proposito del proyecto, en caso de que no haya un actualizar no es necesario 


app.MapGet("/Actor", async (IRepoActor actores) =>
    await actores.AsyncListar);


app.MapPost("/Actor", async (Actores nuevo, IRepoActor actor) =>
{
    await actor.AsyncAlta(nuevo);

    return Results.Created($"/Actor/{nuevo.idActor}", nuevo);
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
