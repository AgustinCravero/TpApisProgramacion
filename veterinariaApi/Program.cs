using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Repositorios;
using veterinariaApi.Logica;
using veterinariaApi.Endpoints; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalLogica, AnimalLogica>();

builder.Services.AddScoped<IDuenioRepository, DuenioRepository>();
builder.Services.AddScoped<IDuenioLogica, DuenioLogica>();

builder.Services.AddScoped<IAtencionRepository, AtencionRepository>();
builder.Services.AddScoped<IAtencionLogica, AtencionLogica>();

builder.Services.AddScoped<ITipoAnimalRepository, TipoAnimalRepository>();
builder.Services.AddScoped<ITipoAnimalLogica, TipoAnimalLogica>();

builder.Services.AddScoped<IRazaRepository, RazaRepository>();
builder.Services.AddScoped<IRazaLogica, RazaLogica>();

builder.Services.AddScoped<ITratamientoRepository, TratamientoRepository>();
builder.Services.AddScoped<ITratamientoLogica, TratamientoLogica>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapAnimalEndpoints();
app.MapDuenioEndpoints();
app.MapAtencionEndpoints();
app.MapTipoAnimalEndpoints();
app.MapRazaEndpoints();
app.MapTratamientoEndpoints();

app.Run();
