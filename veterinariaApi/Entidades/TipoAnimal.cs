namespace veterinariaApi.Entidades;

public class TipoAnimal
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;

    public List<Raza> Razas { get; set; } = new();
    public List<Animal> Animales { get; set; } = new();
}