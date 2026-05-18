using Test.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DI
builder.Services.AddScoped<IWeather, WeatherRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Swagger (dev only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();   //HTTP request কে HTTPS এ convert করে

app.UseDefaultFiles();      //automatically index.html open করে

app.UseStaticFiles();       //HTML, CSS, JS, image serve করে

app.UseCors("AllowAll");    //frontend (React/Angular) কে API call করার permission দেয়

app.UseAuthorization();     //user allowed কিনা check করে

app.MapControllers();       //request কে correct controller method এ পাঠায়

app.Run();                  //সব configuration শেষ, এখন server start করো