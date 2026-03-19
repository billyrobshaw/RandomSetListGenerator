using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;
using MusicApp.API.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("MusicAppDbConnection");

builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connString)
                    .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// For development, allow CORS from localhost:3000 (React dev server)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//For realease, change the IP address to your machine's local IP address and ensure the frontend is running on that IP and port
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontend",
//        policy => policy
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .WithOrigins(
//                "http://localhost:3000",
//                "http://192.168.0.164:3000"
//            )
//    );
//});

var app = builder.Build();

//https://localhost:7169/swagger/index.html
app.UseSwagger();
app.UseSwaggerUI();

app.MapOpenApi();

app.UseDefaultFiles(); // Looks for index.html by default
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
