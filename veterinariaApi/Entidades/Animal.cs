
namespace veterinariaApi.Entidades;

public class Animal
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int IdTipo { get; set; }
    public TipoAnimal? Tipo { get; set; }
    public int IdRaza { get; set; }
    public Raza? Raza { get; set; }
    public int Edad { get; set; }
    public Sexo Sexo { get; set; }
    public int IdDuenio { get; set; }
    public Duenio? Duenio { get; set; }
    public List<Atencion> Atenciones { get; set; } = new();
}

public enum Sexo
{
    Macho = 0,
    Hembra = 1 
}
