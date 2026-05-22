using System.Linq;
using veterinariaApi.Entidades;
using veterinariaApi.Logica.DTOs;
using veterinariaApi.Repositorios;

namespace veterinariaApi.Logica;

public interface IAnimalLogica
{
    Task<IEnumerable<AnimalDto>> ObtenerTodosAsync();
    Task<AnimalDto?> ObtenerPorIdAsync(int id);
    Task<AnimalDto> AgregarAsync(AnimalCreateDto animalCreateDto);
    Task<AnimalDto?> ActualizarAsync(int id, AnimalUpdateDto animalUpdateDto);
    Task<bool> EliminarAsync(int id);
}

public class AnimalLogica : IAnimalLogica
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalLogica(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<IEnumerable<AnimalDto>> ObtenerTodosAsync()
    {
        var animales = await _animalRepository.ObtenerTodos();
        return animales.Select(MapToDto);
    }

    public async Task<AnimalDto?> ObtenerPorIdAsync(int id)
    {
        var animal = await _animalRepository.ObtenerPorId(id);
        return animal is null ? null : MapToDto(animal);
    }

    public async Task<AnimalDto> AgregarAsync(AnimalCreateDto animalCreateDto)
    {
        var animal = new Animal
        {
            Nombre = animalCreateDto.Nombre,
            IdTipo = animalCreateDto.IdTipo,
            IdRaza = animalCreateDto.IdRaza,
            Edad = animalCreateDto.Edad,
            Sexo = animalCreateDto.Sexo,
            IdDuenio = animalCreateDto.IdDuenio
        };

        await _animalRepository.Agregar(animal);
        return MapToDto(animal);
    }

    public async Task<AnimalDto?> ActualizarAsync(int id, AnimalUpdateDto animalUpdateDto)
    {
        if (id != animalUpdateDto.Id)
        {
            return null;
        }

        var existingAnimal = await _animalRepository.ObtenerPorId(id);
        if (existingAnimal is null)
        {
            return null;
        }

        existingAnimal.Nombre = animalUpdateDto.Nombre;
        existingAnimal.IdTipo = animalUpdateDto.IdTipo;
        existingAnimal.IdRaza = animalUpdateDto.IdRaza;
        existingAnimal.Edad = animalUpdateDto.Edad;
        existingAnimal.Sexo = animalUpdateDto.Sexo;
        existingAnimal.IdDuenio = animalUpdateDto.IdDuenio;

        await _animalRepository.Actualizar(existingAnimal);
        return MapToDto(existingAnimal);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existingAnimal = await _animalRepository.ObtenerPorId(id);
        if (existingAnimal is null)
        {
            return false;
        }

        await _animalRepository.Eliminar(id);
        return true;
    }

    private static AnimalDto MapToDto(Animal animal) =>
        new(animal.Id, animal.Nombre, animal.IdTipo, animal.IdRaza, animal.Edad, animal.Sexo, animal.IdDuenio);
}


