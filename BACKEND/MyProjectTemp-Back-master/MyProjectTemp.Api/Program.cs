using Microsoft.OpenApi.Models;
using MyProjectTemp.Infra;

var builder = WebApplication.CreateBuilder(args);

//Injecting services.
builder.Services.RegisterServices();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MyProyectTemp API",
        Description = "MyProyectTemp API"
    });
});

var app = builder.Build();

// Configura el path base si tu aplicación se ejecuta bajo un subdirectorio
app.UsePathBase("/MyProjectTempApi");

if (app.Environment.IsDevelopment())
{
    // Habilitando Swagger en todos los entornos.
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Esta configuración asume que quieres que Swagger sea accesible en la raíz de tu aplicación.
        // Ajusta según sea necesario basado en tu entorno específico o requisitos.
        var swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
        options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "MyProyectTemp API V1");
        options.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();