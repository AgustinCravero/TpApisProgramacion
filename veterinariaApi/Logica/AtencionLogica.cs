using System.Linq;
using veterinariaApi.Entidades;
using veterinariaApi.Logica.DTOs;
using veterinariaApi.Repositorios;

namespace veterinariaApi.Logica;

public interface IAtencionLogica
{
    Task<IEnumerable<AtencionDto>> ObtenerTodosAsync();
    Task<AtencionDto?> ObtenerPorIdAsync(int id);
    Task<AtencionDto> AgregarAsync(AtencionCreateDto atencionCreateDto);
    Task<AtencionDto?> ActualizarAsync(int id, AtencionUpdateDto atencionUpdateDto);
    Task<bool> EliminarAsync(int id);
}

public class AtencionLogica : IAtencionLogica
{
    private readonly IAtencionRepository _atencionRepositorio;

    public AtencionLogica(IAtencionRepository atencionRepositorio)
    {
        _atencionRepositorio = atencionRepositorio;
    }

    public async Task<IEnumerable<AtencionDto>> ObtenerTodosAsync()
    {
        var atenciones = await _atencionRepositorio.ObtenerTodos();
        return atenciones.Select(MapToDto);
    }

    public async Task<AtencionDto?> ObtenerPorIdAsync(int id)
    {
        var atencion = await _atencionRepositorio.ObtenerPorId(id);
        return atencion is null ? null : MapToDto(atencion);
    }

    public async Task<AtencionDto> AgregarAsync(AtencionCreateDto atencionCreateDto)
    {
        var atencion = new Atencion
        {
            Motivo = atencionCreateDto.Motivo,
            IdTratamiento = atencionCreateDto.IdTratamiento,
            Medicamentos = atencionCreateDto.Medicamentos,
            Fecha = atencionCreateDto.Fecha,
            IdAnimal = atencionCreateDto.IdAnimal
        };

        await _atencionRepositorio.Agregar(atencion);
        return MapToDto(atencion);
    }

    public async Task<AtencionDto?> ActualizarAsync(int id, AtencionUpdateDto atencionUpdateDto)
    {
        if (id != atencionUpdateDto.Id)
        {
            return null;
        }

        var existingAtencion = await _atencionRepositorio.ObtenerPorId(id);
        if (existingAtencion is null)
        {
            return null;
        }

        existingAtencion.Motivo = atencionUpdateDto.Motivo;
        existingAtencion.IdTratamiento = atencionUpdateDto.IdTratamiento;
        existingAtencion.Medicamentos = atencionUpdateDto.Medicamentos;
        existingAtencion.Fecha = atencionUpdateDto.Fecha;
        existingAtencion.IdAnimal = atencionUpdateDto.IdAnimal;

        await _atencionRepositorio.Actualizar(existingAtencion);
        return MapToDto(existingAtencion);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existingAtencion = await _atencionRepositorio.ObtenerPorId(id);
        if (existingAtencion is null)
        {
            return false;
        }

        await _atencionRepositorio.Eliminar(id);
        return true;
    }

    private static AtencionDto MapToDto(Atencion atencion) =>
        new(atencion.Id, atencion.Motivo, atencion.IdTratamiento, atencion.Medicamentos, atencion.Fecha, atencion.IdAnimal);
}