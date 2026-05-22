namespace veterinariaApi.Logica.DTOs;

public record AtencionDto(int Id, string Motivo, int IdTratamiento, string Medicamentos, DateTime Fecha, int IdAnimal);
public record AtencionCreateDto(string Motivo, int IdTratamiento, string Medicamentos, DateTime Fecha, int IdAnimal);
public record AtencionUpdateDto(int Id, string Motivo, int IdTratamiento, string Medicamentos, DateTime Fecha, int IdAnimal);
public record AtencionDeleteDto(int Id);
