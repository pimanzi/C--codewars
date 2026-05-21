using FoodieAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapRestaurantEndpoint();
app.Run();
