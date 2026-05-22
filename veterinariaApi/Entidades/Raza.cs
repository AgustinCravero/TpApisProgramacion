namespace veterinariaApi.Entidades;

public class Raza
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;

    public int IdTipo { get; set; }
    public TipoAnimal? Tipo { get; set; }
    public List<Animal> Animales { get; set; } = new();
}