using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;


public class TratamientoRepository : ITratamientoRepository
{
    private readonly AppDbContext _context;

    public TratamientoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tratamiento>> ObtenerTodos() => await _context.Tratamientos.ToListAsync();

    public async Task Agregar(Tratamiento tratamiento)
    {
        _context.Tratamientos.Add(tratamiento);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var tratamiento = await _context.Tratamientos.FindAsync(id);
        if (tratamiento != null)
        {
            _context.Tratamientos.Remove(tratamiento);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Actualizar(Tratamiento tratamiento)
    {
        _context.Tratamientos.Update(tratamiento);
        await _context.SaveChangesAsync();
    }

    public async Task<Tratamiento?> ObtenerPorId(int id) => await _context.Tratamientos.FindAsync(id);
}
