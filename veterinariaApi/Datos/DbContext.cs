using Microsoft.EntityFrameworkCore;
using veterinariaApi.Entidades;

namespace veterinariaApi.Datos;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Animal> Animales => Set<Animal>();
    public DbSet<Duenio> Duenios => Set<Duenio>();
    public DbSet<Atencion> Atenciones => Set<Atencion>();
    public DbSet<Raza> Razas => Set<Raza>();
    public DbSet<TipoAnimal> TiposAnimales => Set<TipoAnimal>();
    public DbSet<Tratamiento> Tratamientos => Set<Tratamiento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar relación Animal -> Duenio
        modelBuilder.Entity<Animal>()
            .HasOne(a => a.Duenio)
            .WithMany(d => d.Animales)
            .HasForeignKey(a => a.IdDuenio)
            .OnDelete(DeleteBehavior.Restrict);

        // Configurar relación Animal -> TipoAnimal
        modelBuilder.Entity<Animal>()
            .HasOne(a => a.Tipo)
            .WithMany(t => t.Animales)
            .HasForeignKey(a => a.IdTipo)
            .OnDelete(DeleteBehavior.Restrict);

        // Configurar relación Animal -> Raza
        modelBuilder.Entity<Animal>()
            .HasOne(a => a.Raza)
            .WithMany(r => r.Animales)
            .HasForeignKey(a => a.IdRaza)
            .OnDelete(DeleteBehavior.Restrict);

        // Configurar relación Atencion -> Tratamiento
        modelBuilder.Entity<Atencion>()
            .HasOne(at => at.Tratamiento)
            .WithMany(t => t.Atenciones)
            .HasForeignKey(at => at.IdTratamiento)
            .OnDelete(DeleteBehavior.Restrict);

        // Configurar relación Atencion -> Animal
        modelBuilder.Entity<Atencion>()
            .HasOne(at => at.Animal)
            .WithMany(a => a.Atenciones)
            .HasForeignKey(at => at.IdAnimal)
            .OnDelete(DeleteBehavior.Cascade);

        // Configurar relación Raza -> TipoAnimal
        modelBuilder.Entity<Raza>()
            .HasOne(r => r.Tipo)
            .WithMany(t => t.Razas)
            .HasForeignKey(r => r.IdTipo)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
