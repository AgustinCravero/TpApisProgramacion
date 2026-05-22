using System.Linq;
using veterinariaApi.Entidades;
using veterinariaApi.Logica.DTOs;
using veterinariaApi.Repositorios;

namespace veterinariaApi.Logica;

public interface IRazaLogica
{
    Task<IEnumerable<RazaDto>> ObtenerTodosAsync();
    Task<RazaDto?> ObtenerPorIdAsync(int id);
    Task<RazaDto> AgregarAsync(RazaCreateDto razaCreateDto);
    Task<RazaDto?> ActualizarAsync(int id, RazaUpdateDto razaUpdateDto);
    Task<bool> EliminarAsync(int id);
}

public class RazaLogica : IRazaLogica
{
    private readonly IRazaRepository _razaRepository;

    public RazaLogica(IRazaRepository razaRepository)
    {
        _razaRepository = razaRepository;
    }

    public async Task<IEnumerable<RazaDto>> ObtenerTodosAsync()
    {
        var razas = await _razaRepository.ObtenerTodos();
        return razas.Select(MapToDto);
    }

    public async Task<RazaDto?> ObtenerPorIdAsync(int id)
    {
        var raza = await _razaRepository.ObtenerPorId(id);
        return raza is null ? null : MapToDto(raza);
    }

    public async Task<RazaDto> AgregarAsync(RazaCreateDto razaCreateDto)
    {
        var raza = new Raza
        {
            Descripcion = razaCreateDto.Descripcion,
            IdTipo = razaCreateDto.IdTipo
        };

        await _razaRepository.Agregar(raza);
        return MapToDto(raza);
    }

    public async Task<RazaDto?> ActualizarAsync(int id, RazaUpdateDto razaUpdateDto)
    {
        if (id != razaUpdateDto.Id)
        {
            return null;
        }

        var existingRaza = await _razaRepository.ObtenerPorId(id);
        if (existingRaza is null)
        {
            return null;
        }

        existingRaza.Descripcion = razaUpdateDto.Descripcion;
        existingRaza.IdTipo = razaUpdateDto.IdTipo;
        await _razaRepository.Actualizar(existingRaza);
        return MapToDto(existingRaza);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existingRaza = await _razaRepository.ObtenerPorId(id);
        if (existingRaza is null)
        {
            return false;
        }

        await _razaRepository.Eliminar(id);
        return true;
    }

    private static RazaDto MapToDto(Raza raza) => new(raza.Id, raza.Descripcion, raza.IdTipo);
}