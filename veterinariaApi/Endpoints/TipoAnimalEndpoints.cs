using veterinariaApi.Logica;
using veterinariaApi.Logica.DTOs;

namespace veterinariaApi.Endpoints;

public static class TipoAnimalEndpoints
{
    public static void MapTipoAnimalEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/tipos-animal", async (ITipoAnimalLogica logica) =>
            Results.Ok(await logica.ObtenerTodosAsync()));

        app.MapGet("/tipos-animal/{id}", async (int id, ITipoAnimalLogica logica) =>
        {
            var tipoAnimal = await logica.ObtenerPorIdAsync(id);
            return tipoAnimal is null ? Results.NotFound() : Results.Ok(tipoAnimal);
        });

        app.MapPost("/tipos-animal", async (TipoAnimalCreateDto dto, ITipoAnimalLogica logica) =>
        {
            var created = await logica.AgregarAsync(dto);
            return Results.Created($"/tipos-animal/{created.Id}", created);
        });

        app.MapPut("/tipos-animal/{id}", async (int id, TipoAnimalUpdateDto dto, ITipoAnimalLogica logica) =>
        {
            if (id != dto.Id)
            {
                return Results.BadRequest();
            }

            var updated = await logica.ActualizarAsync(id, dto);
            return updated is null ? Results.NotFound() : Results.Ok(updated);
        });

        app.MapDelete("/tipos-animal/{id}", async (int id, ITipoAnimalLogica logica) =>
        {
            var deleted = await logica.EliminarAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}