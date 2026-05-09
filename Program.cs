using Microsoft.Data.SqlClient;
using System.Data;
using Test.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// SQL Connection
builder.Services.AddScoped<IWeather>(sp =>
    new WeatherRepository(
        builder.Configuration .GetConnectionString("DefaultConnection")
    ));
// Repository

var app = builder.Build();

app.MapControllers();

app.Run();