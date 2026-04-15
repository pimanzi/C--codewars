using System.Linq;
using ToDoApp.Models;

namespace ToDoApp.Services;

public class TaskManager
{
    private  static List<ToDoItem> _items = new List<ToDoItem>();

    public static void  AddTask(string title, Status? status)
    {
        Status itemStatus = status.HasValue ? status.Value : Status.todo;
        DateTime createdAt= DateTime.Now;
        Guid newId = new Guid();
        ToDoItem item = new ToDoItem(title,itemStatus, createdAt, newId);
        _items.Add(item);
       Console.WriteLine(item.ToString());
    }

    public static void RemoveTask(int id)
    {
        _items.RemoveAll(task => task.Id == id);
        Console.WriteLine($"Task of this {id} has been removed ");
    }
    
}