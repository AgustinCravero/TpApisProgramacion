using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;
public interface IRazaRepository
{
    Task<IEnumerable<Raza>> ObtenerTodos();
    Task Agregar(Raza raza);
    Task Eliminar(int id);
    Task Actualizar(Raza raza);
    Task<Raza?> ObtenerPorId(int id);
}