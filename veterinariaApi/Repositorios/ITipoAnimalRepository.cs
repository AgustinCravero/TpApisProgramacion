using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;

public interface ITipoAnimalRepository
{
    Task<IEnumerable<TipoAnimal>> ObtenerTodos();
    Task Agregar(TipoAnimal tipoAnimal);
    Task Eliminar(int id);
    Task Actualizar(TipoAnimal tipoAnimal);
    Task<TipoAnimal?> ObtenerPorId(int id);
}