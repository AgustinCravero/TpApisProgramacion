namespace veterinariaApi.Logica.DTOs;
public record TratamientoDto(int Id, string Nombre, string Descripcion);
public record TratamientoCreateDto(string Nombre, string Descripcion);
public record TratamientoUpdateDto(int Id, string Nombre, string Descripcion);
public record TratamientoDeleteDto(int Id);
