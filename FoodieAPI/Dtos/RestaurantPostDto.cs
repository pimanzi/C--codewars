using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Dtos;

public record RestaurantPostDto(
    [Required] [StringLength(50)] string Name,
    [Required] TimeOnly OpenTime, 
    [Required] TimeOnly CloseTime, 
    [Required] string Description, 
    [Required] string Location,
    [Required] string CuisineType,
    [Required] string? PhoneNumber);