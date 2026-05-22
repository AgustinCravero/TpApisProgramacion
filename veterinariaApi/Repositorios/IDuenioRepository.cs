using System.Collections.Generic;
using System.Threading.Tasks;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;

public interface IDuenioRepository {
    Task<IEnumerable<Duenio>> ObtenerTodos();
    Task Agregar(Duenio duenio);
    Task Eliminar(int id);
    Task Actualizar(Duenio duenio);
    Task<Duenio?> ObtenerPorId(int id);
}