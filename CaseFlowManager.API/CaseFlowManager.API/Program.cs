using CaseFlowManager.API.Service.Interfaces;
using CaseFlowManager.API.Service.Services;
using IMotionSoftware.CaseFlowDataPackage.Infrastructure.Data;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
using IMotionSoftware.CaseFlowDataPackage.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Register API Service Interfaces
builder.Services.AddTransient<IRoleService, RoleService>();

// Register Repo Interfaces
builder.Services.AddTransient<IRoleRepo, RoleRepo>();

builder.Services.AddSingleton<IDbConnectionFactory>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    //var connString = config.GetConnectionString("Default")
    //                 ?? throw new InvalidOperationException("Missing 'Default' connection string");
    return new DbConnectionFactory(config, "Default");
});
builder.Services.AddTransient<ISqlRunner, DapperSqlRunner>();

//builder.Services.AddTransient<IMultiReader, DapperMultiReader>();

// Swagger / OpenAPI via Swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Case Flow Manager API",
        Version = "v1",
        Description = "API for managing case flows"
    });

    // Include XML comments if generated
    var xmlFile = "IMotionSoftware.CaseFlowManager.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                        // /swagger/v1/swagger.json
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Case Flow Manager API v1");
        c.DocumentTitle = "CaseFlow Manager API Docs";
        c.ConfigObject.AdditionalItems["validatorUrl"] = null; // equivalent to DisableValidator
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();