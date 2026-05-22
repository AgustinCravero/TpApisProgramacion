using System.Collections.Generic;
using System.Threading.Tasks;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;

public interface IAnimalRepository {
    Task<IEnumerable<Animal>> ObtenerTodos();
    Task Agregar(Animal animal);
    Task Eliminar(int id);
    Task Actualizar(Animal animal);
    Task<Animal?> ObtenerPorId(int id);
}