using veterinariaApi.Entidades;
namespace veterinariaApi.Logica.DTOs;


public record AnimalDto(int Id, string Nombre, int IdTipo, int IdRaza, int Edad, Sexo Sexo, int IdDuenio);
public record AnimalCreateDto(string Nombre, int IdTipo, int IdRaza, int Edad, Sexo Sexo, int IdDuenio);
public record AnimalUpdateDto(int Id, string Nombre, int IdTipo, int IdRaza, int Edad, Sexo Sexo, int IdDuenio);
public record AnimalDeleteDto(int Id);
public record AnimalListDto(int Id, string Nombre, string Tipo, string Raza, int Edad, Sexo Sexo, string Duenio);

