namespace veterinariaApi.Logica.DTOs;
public record RazaDto(int Id, string Descripcion, int IdTipo);
public record RazaCreateDto(string Descripcion, int IdTipo);
public record RazaUpdateDto(int Id, string Descripcion, int IdTipo);
public record RazaDeleteDto(int Id);