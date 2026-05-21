namespace FoodieAPI.Dtos;

public record RestaurantPatchDto(
    string? Name,
    TimeOnly? OpenTime,
    TimeOnly? CloseTime,
    string? Description,
    string? Location,
    string? CuisineType,
    string? PhoneNumber
);