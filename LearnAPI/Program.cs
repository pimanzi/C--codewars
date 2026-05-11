using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var todos = new List<ToDo>();
app.MapGet("/", () => todos);
app.MapPost("/todos", (ToDo task) =>
{
    todos.Add(task);
    return TypedResults.Created("/todos/{id}", task);
});
app.MapGet("/todos/{id}", Results<Ok<ToDo>, NotFound> (int id) =>
{
    var targetTodo= todos.SingleOrDefault((todo)=> todo.id == id);
    if (targetTodo == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok(targetTodo);
});

app.MapDelete("/todos", (int id) =>
{
    todos.RemoveAll((todo) => todo.id == id);
    return TypedResults.NoContent();
});
app.Run();
public record ToDo(int id, string name, DateTime date, bool isCompleted);