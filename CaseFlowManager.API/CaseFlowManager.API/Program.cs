using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.SwaggerUi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen(c => 
//{
//    c.SwaggerDog("v1", new OpenApiInfo
//    {
//        Title = "Case Flow Manager API",
//        Description = "API for managing case flows",
//        Version = "v1"
//    });

//    var xmlName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlName);
//    if (File.Exists(xmlPath))
//    {
//        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
//    }
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
