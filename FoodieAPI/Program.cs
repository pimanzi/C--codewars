using FoodieAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var app = builder.Build();

app.MapRestaurantEndpoint();
app.Run();
