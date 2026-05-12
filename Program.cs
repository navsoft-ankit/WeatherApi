using Microsoft.Data.SqlClient;
using System.Data;
using Test.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// SQL Connection
builder.Services.AddScoped<IWeather>(sp =>
    new WeatherRepository(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
});

var app = builder.Build();

// 🔥 IMPORTANT (THIS WAS MISSING)
app.UseDefaultFiles();   // loads index.html automatically
app.UseStaticFiles();    // enables wwwroot

app.UseCors("AllowAll");

app.MapControllers();

app.Run();