using veterinariaApi.Logica;
using veterinariaApi.Logica.DTOs;

namespace veterinariaApi.Endpoints;

public static class DuenioEndpoints
{
    public static void MapDuenioEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/duenios", async (IDuenioLogica logica) =>
            Results.Ok(await logica.ObtenerTodosAsync()));

        app.MapGet("/duenios/{id}", async (int id, IDuenioLogica logica) =>
        {
            var duenio = await logica.ObtenerPorIdAsync(id);
            return duenio is null ? Results.NotFound() : Results.Ok(duenio);
        });

        app.MapPost("/duenios", async (DuenioCreateDto dto, IDuenioLogica logica) =>
        {
            var created = await logica.AgregarAsync(dto);
            return Results.Created($"/duenios/{created.Id}", created);
        });

        app.MapPut("/duenios/{id}", async (int id, DuenioUpdateDto dto, IDuenioLogica logica) =>
        {

            var updated = await logica.ActualizarAsync(id, dto);
            return updated is null ? Results.NotFound() : Results.Ok(updated);
        });

        app.MapDelete("/duenios/{id}", async (int id, IDuenioLogica logica) =>
        {
            var deleted = await logica.EliminarAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}
