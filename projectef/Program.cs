// Importar los espacios de nombres necesarios
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef; // Supongamos que este es el espacio de nombres donde está definida la clase TareasContext

// Crear un constructor de aplicación web
var builder = WebApplication.CreateBuilder(args);

// Registrar el contexto de base de datos (interactuar con la DB) en el contenedor de servicios de la aplicación
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

// Construir la aplicación web
var app = builder.Build();

// Definir un punto de acceso para la ruta raíz
app.MapGet("/", () => "Hello World!");

// Definir otro punto de acceso (end point) para verificar la conexión a la base de datos
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    try
    {
        // Asegurarse de que la base de datos está creada
        dbContext.Database.EnsureCreated();
        // Verificar si la base de datos está en memoria y retornar un mensaje adecuado
        return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    }
    catch (Exception e)
    {
        // Capturar y manejar cualquier error que ocurra durante la verificación de la base de datos
        return Results.Ok("Error al verificar la base de datos en memoria: " + e.Message);
    }
});

// Iniciar la aplicación web y mantenerla en ejecución para manejar las solicitudes entrantes
app.Run();
