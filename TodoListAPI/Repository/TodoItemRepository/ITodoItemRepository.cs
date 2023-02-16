using TodoListAPI.Models;

namespace TodoListAPI.Repository.TodoItemRepository;

public interface ITodoItemRepository
{
    Task<List<TodoItem>> GetTodoItemsAsync();
    Task<bool> AnyAsync(int ID);
    Task<int> GetTodoItemCount();
    Task<TodoItem> GetTodoItemAsync(int ID);
    Task<bool> CreateAsync(TodoItem TodoItem);
    Task<bool> UpdateAsync(TodoItem TodoItem);
    Task<TodoItem> GetAsync(int ID);
    Task<bool> DeleteAsync(int ID);
}
