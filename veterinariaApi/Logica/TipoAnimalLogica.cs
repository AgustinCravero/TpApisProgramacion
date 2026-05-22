using System.Linq;
using veterinariaApi.Entidades;
using veterinariaApi.Logica.DTOs;
using veterinariaApi.Repositorios;

namespace veterinariaApi.Logica;

public interface ITipoAnimalLogica
{
    Task<IEnumerable<TipoAnimalDto>> ObtenerTodosAsync();
    Task<TipoAnimalDto?> ObtenerPorIdAsync(int id);
    Task<TipoAnimalDto> AgregarAsync(TipoAnimalCreateDto tipoAnimalCreateDto);
    Task<TipoAnimalDto?> ActualizarAsync(int id, TipoAnimalUpdateDto tipoAnimalUpdateDto);
    Task<bool> EliminarAsync(int id);
}

public class TipoAnimalLogica : ITipoAnimalLogica
{
    private readonly ITipoAnimalRepository _tipoAnimalRepository;

    public TipoAnimalLogica(ITipoAnimalRepository tipoAnimalRepository)
    {
        _tipoAnimalRepository = tipoAnimalRepository;
    }

    public async Task<IEnumerable<TipoAnimalDto>> ObtenerTodosAsync()
    {
        var tipos = await _tipoAnimalRepository.ObtenerTodos();
        return tipos.Select(MapToDto);
    }

    public async Task<TipoAnimalDto?> ObtenerPorIdAsync(int id)
    {
        var tipoAnimal = await _tipoAnimalRepository.ObtenerPorId(id);
        return tipoAnimal is null ? null : MapToDto(tipoAnimal);
    }

    public async Task<TipoAnimalDto> AgregarAsync(TipoAnimalCreateDto tipoAnimalCreateDto)
    {
        var tipoAnimal = new TipoAnimal
        {
            Descripcion = tipoAnimalCreateDto.Descripcion
        };

        await _tipoAnimalRepository.Agregar(tipoAnimal);
        return MapToDto(tipoAnimal);
    }

    public async Task<TipoAnimalDto?> ActualizarAsync(int id, TipoAnimalUpdateDto tipoAnimalUpdateDto)
    {
        if (id != tipoAnimalUpdateDto.Id)
        {
            return null;
        }

        var existingTipoAnimal = await _tipoAnimalRepository.ObtenerPorId(id);
        if (existingTipoAnimal is null)
        {
            return null;
        }

        existingTipoAnimal.Descripcion = tipoAnimalUpdateDto.Descripcion;
        await _tipoAnimalRepository.Actualizar(existingTipoAnimal);
        return MapToDto(existingTipoAnimal);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existingTipoAnimal = await _tipoAnimalRepository.ObtenerPorId(id);
        if (existingTipoAnimal is null)
        {
            return false;
        }

        await _tipoAnimalRepository.Eliminar(id);
        return true;
    }

    private static TipoAnimalDto MapToDto(TipoAnimal tipoAnimal) => new(tipoAnimal.Id, tipoAnimal.Descripcion);
}