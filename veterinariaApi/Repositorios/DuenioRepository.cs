using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;
public class DuenioRepository : IDuenioRepository
{
    private readonly AppDbContext _context;

    public DuenioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Duenio>> ObtenerTodos()
    {
        return await _context.Duenios.ToListAsync();
    }

    public async Task Agregar(Duenio duenio)
    {
        _context.Duenios.Add(duenio);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var duenio = await _context.Duenios.FindAsync(id);
        if (duenio != null)
        {
            _context.Duenios.Remove(duenio);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Actualizar(Duenio duenio)
    {
        _context.Duenios.Update(duenio);
        await _context.SaveChangesAsync();
    }

    public async Task<Duenio?> ObtenerPorId(int id)
    {
        return await _context.Duenios.FindAsync(id);
    }
}