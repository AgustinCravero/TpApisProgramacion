using System.Collections.Generic;
using System.Threading.Tasks;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;

public interface IAtencionRepository {
    Task<IEnumerable<Atencion>> ObtenerTodos();
    Task Agregar(Atencion atencion);
    Task Eliminar(int id);
    Task Actualizar(Atencion atencion);
    Task<Atencion?> ObtenerPorId(int id);
}