using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;

public class RazaRepository : IRazaRepository
{
    private readonly AppDbContext _context;

    public RazaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Raza>> ObtenerTodos() => await _context.Razas.ToListAsync();

    public async Task Agregar(Raza raza)
    {
        _context.Razas.Add(raza);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var raza = await _context.Razas.FindAsync(id);
        if (raza != null)
        {
            _context.Razas.Remove(raza);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Actualizar(Raza raza)
    {
        _context.Razas.Update(raza);
        await _context.SaveChangesAsync();
    }

    public async Task<Raza?> ObtenerPorId(int id) => await _context.Razas.FindAsync(id);
}