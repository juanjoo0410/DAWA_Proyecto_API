using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.Models;
using TiendaMascotas_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options => options.AddPolicy("Policy",
                                builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod()));

//Context
builder.Services.AddDbContext<PeluditosDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));

});

//Automapper
builder.Services.AddAutoMapper(typeof(Program));

//Inyecci�n de dependencias
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CarritoRepository>();
builder.Services.AddScoped<EstadoCivilRepository>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<TipoPagoRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
