using System.Linq;
using veterinariaApi.Entidades;
using veterinariaApi.Logica.DTOs;
using veterinariaApi.Repositorios;

namespace veterinariaApi.Logica;

public interface IDuenioLogica
{
    Task<IEnumerable<DuenioDto>> ObtenerTodosAsync();
    Task<DuenioDto?> ObtenerPorIdAsync(int id);
    Task<DuenioDto> AgregarAsync(DuenioCreateDto duenioCreateDto);
    Task<DuenioDto?> ActualizarAsync(int id, DuenioUpdateDto duenioUpdateDto);
    Task<bool> EliminarAsync(int id);
}

public class DuenioLogica : IDuenioLogica
{
    private readonly IDuenioRepository _duenioRepositorio;

    public DuenioLogica(IDuenioRepository duenioRepositorio)
    {
        _duenioRepositorio = duenioRepositorio;
    }

    public async Task<IEnumerable<DuenioDto>> ObtenerTodosAsync()
    {
        var duenios = await _duenioRepositorio.ObtenerTodos();
        return duenios.Select(MapToDto);
    }

    public async Task<DuenioDto?> ObtenerPorIdAsync(int id)
    {
        var duenio = await _duenioRepositorio.ObtenerPorId(id);
        return duenio is null ? null : MapToDto(duenio);
    }

    public async Task<DuenioDto> AgregarAsync(DuenioCreateDto duenioCreateDto)
    {
        var duenio = new Duenio
        {
            Dni = duenioCreateDto.Dni,
            Nombre = duenioCreateDto.Nombre,
            Apellido = duenioCreateDto.Apellido
        };

        await _duenioRepositorio.Agregar(duenio);
        return MapToDto(duenio);
    }

    public async Task<DuenioDto?> ActualizarAsync(int id, DuenioUpdateDto duenioUpdateDto)
    {

        var existingDuenio = await _duenioRepositorio.ObtenerPorId(id);
        if (existingDuenio is null)
        {
            return null;
        }

        existingDuenio.Dni = duenioUpdateDto.Dni;
        existingDuenio.Nombre = duenioUpdateDto.Nombre;
        existingDuenio.Apellido = duenioUpdateDto.Apellido;

        await _duenioRepositorio.Actualizar(existingDuenio);
        return MapToDto(existingDuenio);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existingDuenio = await _duenioRepositorio.ObtenerPorId(id);
        if (existingDuenio is null)
        {
            return false;
        }

        await _duenioRepositorio.Eliminar(id);
        return true;
    }

    private static DuenioDto MapToDto(Duenio duenio) =>
        new(duenio.Id, duenio.Dni, duenio.Nombre, duenio.Apellido);
}