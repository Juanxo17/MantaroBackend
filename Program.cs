using MantaroBot.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar CORS para permitir que React (puerto 5173 o URL de Netlify) hable con C#
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReact", policy =>
    {
        var frontendUrl = builder.Configuration["FRONTEND_URL"];
        
        policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173", "https://mantaroginebra.netlify.app")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Importante por si a futuro hay cookies/sesiones complejas

        // Si existe la variable FRONTEND_URL en Render, la añadimos a los orígenes permitidos
        if (!string.IsNullOrEmpty(frontendUrl))
        {
            policy.WithOrigins(frontendUrl)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
        else
        {
            // Opcional para MVP: Permitir cualquiera si no has configurado la variable
            policy.SetIsOriginAllowed(origin => true); 
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddSingleton<SesionService>();

var app = builder.Build();

// 2. Activar CORS (Siempre ANTES de mapear Controladores)
app.UseCors("PermitirReact");

app.MapControllers();

app.MapGet("/", () => "Hola cracks mi nombre es donato y sean bienvenidos a mi servidor en c#");

Console.WriteLine("Servidor de Mantaro corriendo melo, esperando a React...");

app.Run();