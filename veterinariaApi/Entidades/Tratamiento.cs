namespace veterinariaApi.Entidades;

public class Tratamiento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;

    public List<Atencion> Atenciones { get; set; } = new();
}