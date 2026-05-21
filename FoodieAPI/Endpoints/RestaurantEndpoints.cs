using FoodieAPI.Dtos;

namespace FoodieAPI.Endpoints;

public static class RestaurantEndpoints
{
    static List<RestaurantDto> restaurants = [
        new RestaurantDto(
            1,
            "Bella Italia",
            new TimeOnly(11, 0),  
            new TimeOnly(22, 0),  
            "Authentic Italian cuisine in the heart of Kigali",
            "Kigali, Rwanda",
            "Italian",
            "+250781234567"
        ),
        new RestaurantDto(
            2,
            "Dragon Palace",
            new TimeOnly(12, 0),  
            new TimeOnly(23, 0),   
            "Traditional Chinese dishes and dim sum",
            "Kigali, Rwanda",
            "Chinese",
            "+250782345678"
        ),
        new RestaurantDto(
            3,
            "Kigali Grill",
            new TimeOnly(10, 0),  
            new TimeOnly(21, 0),   
            "Best African grilled meat and local dishes",
            "Kigali, Rwanda",
            "African",
            null                   
        ),
        new RestaurantDto(
            4,
            "Sushi Kingdom",
            new TimeOnly(13, 0),   
            new TimeOnly(23, 30),  
            "Fresh Japanese sushi and ramen bowls",
            "Kigali, Rwanda",
            "Japanese",
            "+250783456789"
        ),
        new RestaurantDto(
            5,
            "Burger House",
            new TimeOnly(9, 0),   
            new TimeOnly(22, 30),  
            "Juicy burgers and crispy fries since 2010",
            "Kigali, Rwanda",
            "American",
            "+250784567890"
        )
    ];
    public static void MapRestaurantEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("restaurant");

        app.MapGet("/", () => restaurants);
        app.MapGet("/{id}", (int id) =>
        {
            int restaurantIndex = restaurants.FindIndex(x => x.Id == id);
            return restaurantIndex == -1  ? Results.NotFound() : Results.Ok(restaurants[restaurantIndex]);
        }).WithName("GetRestaurant");

        app.MapPost("/", (RestaurantPostDto data) =>
        {
            RestaurantDto newRestaurant = new(
                restaurants.Count + 1,
                data.Name,
                data.OpenTime,
                data.CloseTime,
                data.Description,
                data.Location,
                data.CuisineType,
                data?.PhoneNumber

            );
            restaurants.Add(newRestaurant);
            return Results.CreatedAtRoute("GetRestaurant", new { id = newRestaurant.Id }, newRestaurant);
        });

        app.MapPatch("/{id}", (int id, RestaurantPatchDto updatedRestaurant) =>
        {
            int restaurantIndex = restaurants.FindIndex(x => x.Id == id);
            if (restaurantIndex == -1) return Results.NotFound();

            RestaurantDto updateRestaurant = restaurants[restaurantIndex];
            RestaurantDto newRestaurant = updateRestaurant with
            {
                Id = id,
                Name = updatedRestaurant.Name ?? updateRestaurant.Name,
                OpenTime = updatedRestaurant.OpenTime ?? updateRestaurant.OpenTime,
                CloseTime = updatedRestaurant.CloseTime ?? updateRestaurant.CloseTime,
                Description = updatedRestaurant.Description ?? updateRestaurant.Description,
                Location = updatedRestaurant.Location ?? updateRestaurant.Location,
                CuisineType = updatedRestaurant.CuisineType ?? updateRestaurant.CuisineType,
                PhoneNumber = updatedRestaurant.PhoneNumber ?? updateRestaurant.PhoneNumber

            };
            
            restaurants[restaurantIndex] = newRestaurant;
            return Results.NoContent();
        });

        app.MapDelete("/{id}", (int id) =>
        {
            restaurants.RemoveAll(x => x.Id == id);
            return Results.NoContent();
        });
    }
}