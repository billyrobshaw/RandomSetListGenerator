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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()   // or restrict to "https://localhost:5002"
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});



var app = builder.Build();

//https://localhost:7169/swagger/index.html
app.UseSwagger();
app.UseSwaggerUI();

app.MapOpenApi();

app.UseDefaultFiles(); // Looks for index.html by default
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
