using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;

public class TipoAnimalRepository : ITipoAnimalRepository
{
    private readonly AppDbContext _context;

    public TipoAnimalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TipoAnimal>> ObtenerTodos() => await _context.TiposAnimales.ToListAsync();

    public async Task Agregar(TipoAnimal tipoAnimal)
    {
        _context.TiposAnimales.Add(tipoAnimal);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var tipoAnimal = await _context.TiposAnimales.FindAsync(id);
        if (tipoAnimal != null)
        {
            _context.TiposAnimales.Remove(tipoAnimal);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Actualizar(TipoAnimal tipoAnimal)
    {
        _context.TiposAnimales.Update(tipoAnimal);
        await _context.SaveChangesAsync();
    }

    public async Task<TipoAnimal?> ObtenerPorId(int id) => await _context.TiposAnimales.FindAsync(id);
}