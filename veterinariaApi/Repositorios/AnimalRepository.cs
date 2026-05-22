using Microsoft.EntityFrameworkCore;
using veterinariaApi.Datos;
using veterinariaApi.Entidades;

namespace veterinariaApi.Repositorios;
public class AnimalRepository : IAnimalRepository
{
    private readonly AppDbContext _context;

    public AnimalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Animal>> ObtenerTodos()
    {
        return await _context.Animales.ToListAsync();
    }

    public async Task Agregar(Animal animal)
    {
        _context.Animales.Add(animal);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var animal = await _context.Animales.FindAsync(id);
        if (animal != null)
        {
            _context.Animales.Remove(animal);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Actualizar(Animal animal)
    {
        _context.Animales.Update(animal);
        await _context.SaveChangesAsync();
    }

    public async Task<Animal?> ObtenerPorId(int id)
    {
        return await _context.Animales.FindAsync(id);
    }
}

