using veterinariaApi.Logica;
using veterinariaApi.Logica.DTOs;

namespace veterinariaApi.Endpoints;

public static class TratamientoEndpoints
{
    public static void MapTratamientoEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/tratamientos", async (ITratamientoLogica logica) =>
            Results.Ok(await logica.ObtenerTodosAsync()));

        app.MapGet("/tratamientos/{id}", async (int id, ITratamientoLogica logica) =>
        {
            var tratamiento = await logica.ObtenerPorIdAsync(id);
            return tratamiento is null ? Results.NotFound() : Results.Ok(tratamiento);
        });

        app.MapPost("/tratamientos", async (TratamientoCreateDto dto, ITratamientoLogica logica) =>
        {
            var created = await logica.AgregarAsync(dto);
            return Results.Created($"/tratamientos/{created.Id}", created);
        });

        app.MapPut("/tratamientos/{id}", async (int id, TratamientoUpdateDto dto, ITratamientoLogica logica) =>
        {
            if (id != dto.Id)
            {
                return Results.BadRequest();
            }

            var updated = await logica.ActualizarAsync(id, dto);
            return updated is null ? Results.NotFound() : Results.Ok(updated);
        });

        app.MapDelete("/tratamientos/{id}", async (int id, ITratamientoLogica logica) =>
        {
            var deleted = await logica.EliminarAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}
