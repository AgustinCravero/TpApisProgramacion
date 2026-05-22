using veterinariaApi.Logica;
using veterinariaApi.Logica.DTOs;

namespace veterinariaApi.Endpoints;

public static class RazaEndpoints
{
    public static void MapRazaEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/razas", async (IRazaLogica logica) =>
            Results.Ok(await logica.ObtenerTodosAsync()));

        app.MapGet("/razas/{id}", async (int id, IRazaLogica logica) =>
        {
            var raza = await logica.ObtenerPorIdAsync(id);
            return raza is null ? Results.NotFound() : Results.Ok(raza);
        });

        app.MapPost("/razas", async (RazaCreateDto dto, IRazaLogica logica) =>
        {
            var created = await logica.AgregarAsync(dto);
            return Results.Created($"/razas/{created.Id}", created);
        });

        app.MapPut("/razas/{id}", async (int id, RazaUpdateDto dto, IRazaLogica logica) =>
        {
            if (id != dto.Id)
            {
                return Results.BadRequest();
            }

            var updated = await logica.ActualizarAsync(id, dto);
            return updated is null ? Results.NotFound() : Results.Ok(updated);
        });

        app.MapDelete("/razas/{id}", async (int id, IRazaLogica logica) =>
        {
            var deleted = await logica.EliminarAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}