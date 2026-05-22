namespace veterinariaApi.Entidades;

public class Atencion
{
    public int Id { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public int IdTratamiento { get; set; }
    public Tratamiento? Tratamiento { get; set; }
    public string Medicamentos { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public int IdAnimal { get; set; }
    public Animal? Animal { get; set; }
}
