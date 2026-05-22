using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;

public interface ITratamientoRepository
{
    Task<IEnumerable<Tratamiento>> ObtenerTodos();
    Task Agregar(Tratamiento tratamiento);
    Task Eliminar(int id);
    Task Actualizar(Tratamiento tratamiento);
    Task<Tratamiento?> ObtenerPorId(int id);
}