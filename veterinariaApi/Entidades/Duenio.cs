
namespace veterinariaApi.Entidades;

public class Duenio
{
    public int Id { get; set; }
    public string Dni { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public List<Animal> Animales { get; set; } = new();
}
