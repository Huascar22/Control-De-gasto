using Controlador;
using Microsoft.EntityFrameworkCore;
using Modelo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>{
    options.AddPolicy("Permisos",
        builder =>{
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});

var conexion = builder.Configuration.GetConnectionString("usuarioConnect");
builder.Services.AddDbContext<UsuarioContext>( C => C.UseSqlServer(conexion));

builder.Services.AddScoped<LogicaUsuarios>();
builder.Services.AddScoped<LogicaCategoria>();
builder.Services.AddScoped<LogicaGasto>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Permisos");

app.MapControllers();

app.Run();
