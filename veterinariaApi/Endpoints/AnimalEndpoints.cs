using veterinariaApi.Logica;
using veterinariaApi.Logica.DTOs;

namespace veterinariaApi.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/animales", async (IAnimalLogica logica) =>
            Results.Ok(await logica.ObtenerTodosAsync()));

        app.MapGet("/animales/{id}", async (int id, IAnimalLogica logica) =>
        {
            var animal = await logica.ObtenerPorIdAsync(id);
            return animal is null ? Results.NotFound() : Results.Ok(animal);
        });

        app.MapPost("/animales", async (AnimalCreateDto animalCreateDto, IAnimalLogica logica) =>
        {
            var animal = await logica.AgregarAsync(animalCreateDto);
            return Results.Created($"/animales/{animal.Id}", animal);
        });

        app.MapPut("/animales/{id}", async (int id, AnimalUpdateDto animalUpdateDto, IAnimalLogica logica) =>
        {
            if (id != animalUpdateDto.Id)
            {
                return Results.BadRequest();
            }

            var updated = await logica.ActualizarAsync(id, animalUpdateDto);
            return updated is null ? Results.NotFound() : Results.Ok(updated);
        });

        app.MapDelete("/animales/{id}", async (int id, IAnimalLogica logica) =>
        {
            var deleted = await logica.EliminarAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
} 