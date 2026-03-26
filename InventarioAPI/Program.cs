using Microsoft.EntityFrameworkCore;
using InventarioAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS ---

// Soporte para controladores (Obligatorio para el AuthController)
builder.Services.AddControllers();

// Configuración de Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swashbuckle lo configura automáticamente aquí

// Configuración de CORS para que Blazor (puerto 5034) pueda entrar
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirBlazor", policy =>
        policy.WithOrigins("http://localhost:5034")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Conexión a la base de datos de Supabase
builder.Services.AddDbContext<InventarioDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// --- 2. CONFIGURACIÓN DEL PIPELINE (ORDEN IMPORTANTE) ---

// Habilitar Swagger en modo Desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto crea la página en /swagger
}

// IMPORTANTE: El orden de estos tres es vital
app.UseCors("PermitirBlazor");

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear las rutas de la API
app.MapControllers();

// Ruta de prueba rápida
app.MapGet("/", () => "API de Inventario VIVA y funcionando perfectamente.");

app.Run(); 

