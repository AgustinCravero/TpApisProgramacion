using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;
public class AtencionRepository : IAtencionRepository
{
    private readonly AppDbContext _context;

    public AtencionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Atencion>> ObtenerTodos()
    {
        return await _context.Atenciones.ToListAsync();
    }

    public async Task Agregar(Atencion atencion)
    {
        _context.Atenciones.Add(atencion);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var atencion = await _context.Atenciones.FindAsync(id);
        if (atencion != null)
        {
            _context.Atenciones.Remove(atencion);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Actualizar(Atencion atencion)
    {
        _context.Atenciones.Update(atencion);
        await _context.SaveChangesAsync();
    }

    public async Task<Atencion?> ObtenerPorId(int id)
    {
        return await _context.Atenciones.FindAsync(id);
    }
}