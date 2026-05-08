using Microsoft.Data.SqlClient;
using System.Data;
using Test.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// SQL Connection
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository
builder.Services.AddScoped<IWeather, WeatherRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();