namespace veterinariaApi.Logica.DTOs;

public record DuenioDto(int Id, string Dni, string Nombre, string Apellido);
public record DuenioCreateDto(string Dni, string Nombre, string Apellido);
public record DuenioUpdateDto(string Dni, string Nombre, string Apellido);
public record DuenioDeleteDto(int Id);

