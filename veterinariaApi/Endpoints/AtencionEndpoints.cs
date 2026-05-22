using veterinariaApi.Logica;
using veterinariaApi.Logica.DTOs;

namespace veterinariaApi.Endpoints;

public static class AtencionEndpoints
{
    public static void MapAtencionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/atenciones", async (IAtencionLogica logica) =>
            Results.Ok(await logica.ObtenerTodosAsync()));

        app.MapGet("/atenciones/{id}", async (int id, IAtencionLogica logica) =>
        {
            var atencion = await logica.ObtenerPorIdAsync(id);
            return atencion is null ? Results.NotFound() : Results.Ok(atencion);
        });

        app.MapPost("/atenciones", async (AtencionCreateDto dto, IAtencionLogica logica) =>
        {
            var created = await logica.AgregarAsync(dto);
            return Results.Created($"/atenciones/{created.Id}", created);
        });

        app.MapPut("/atenciones/{id}", async (int id, AtencionUpdateDto dto, IAtencionLogica logica) =>
        {
            if (id != dto.Id)
            {
                return Results.BadRequest();
            }

            var updated = await logica.ActualizarAsync(id, dto);
            return updated is null ? Results.NotFound() : Results.Ok(updated);
        });

        app.MapDelete("/atenciones/{id}", async (int id, IAtencionLogica logica) =>
        {
            var deleted = await logica.EliminarAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}
