using System.Linq;
using veterinariaApi.Entidades;
using veterinariaApi.Logica.DTOs;
using veterinariaApi.Repositorios;

namespace veterinariaApi.Logica;

public interface ITratamientoLogica
{
    Task<IEnumerable<TratamientoDto>> ObtenerTodosAsync();
    Task<TratamientoDto?> ObtenerPorIdAsync(int id);
    Task<TratamientoDto> AgregarAsync(TratamientoCreateDto tratamientoCreateDto);
    Task<TratamientoDto?> ActualizarAsync(int id, TratamientoUpdateDto tratamientoUpdateDto);
    Task<bool> EliminarAsync(int id);
}

public class TratamientoLogica : ITratamientoLogica
{
    private readonly ITratamientoRepository _tratamientoRepository;

    public TratamientoLogica(ITratamientoRepository tratamientoRepository)
    {
        _tratamientoRepository = tratamientoRepository;
    }

    public async Task<IEnumerable<TratamientoDto>> ObtenerTodosAsync()
    {
        var tratamientos = await _tratamientoRepository.ObtenerTodos();
        return tratamientos.Select(MapToDto);
    }

    public async Task<TratamientoDto?> ObtenerPorIdAsync(int id)
    {
        var tratamiento = await _tratamientoRepository.ObtenerPorId(id);
        return tratamiento is null ? null : MapToDto(tratamiento);
    }

    public async Task<TratamientoDto> AgregarAsync(TratamientoCreateDto tratamientoCreateDto)
    {
        var tratamiento = new Tratamiento
        {
            Nombre = tratamientoCreateDto.Nombre,
            Descripcion = tratamientoCreateDto.Descripcion
        };

        await _tratamientoRepository.Agregar(tratamiento);
        return MapToDto(tratamiento);
    }

    public async Task<TratamientoDto?> ActualizarAsync(int id, TratamientoUpdateDto tratamientoUpdateDto)
    {
        if (id != tratamientoUpdateDto.Id)
        {
            return null;
        }

        var existingTratamiento = await _tratamientoRepository.ObtenerPorId(id);
        if (existingTratamiento is null)
        {
            return null;
        }

        existingTratamiento.Nombre = tratamientoUpdateDto.Nombre;
        existingTratamiento.Descripcion = tratamientoUpdateDto.Descripcion;
        await _tratamientoRepository.Actualizar(existingTratamiento);
        return MapToDto(existingTratamiento);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existingTratamiento = await _tratamientoRepository.ObtenerPorId(id);
        if (existingTratamiento is null)
        {
            return false;
        }

        await _tratamientoRepository.Eliminar(id);
        return true;
    }

    private static TratamientoDto MapToDto(Tratamiento tratamiento) =>
        new(tratamiento.Id, tratamiento.Nombre, tratamiento.Descripcion);
}
