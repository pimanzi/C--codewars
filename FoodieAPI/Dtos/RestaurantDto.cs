namespace FoodieAPI.Dtos;

public record RestaurantDto(
    int Id,
    string Name,
    TimeOnly OpenTime, 
    TimeOnly CloseTime, 
    string Description, 
    string Location,
    string CuisineType,
    string? PhoneNumber
    
    );