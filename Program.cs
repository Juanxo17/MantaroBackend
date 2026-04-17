using MantaroBot.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar CORS para permitir que React (puerto 5173 o URL de Netlify de cualquier rama) hable con C#
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReact", policy =>
    {
        // Esto permite cualquier origen (incluyendo previews de Netlify temporales)
        policy.SetIsOriginAllowed(origin => true)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); 
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
