namespace veterinariaApi.Logica.DTOs;
public record TipoAnimalDto(int Id, string Descripcion);
public record TipoAnimalCreateDto(string Descripcion);
public record TipoAnimalUpdateDto(int Id, string Descripcion);
public record TipoAnimalDeleteDto(int Id);



