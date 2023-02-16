using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;

namespace TodoListAPI.Repository.TodoItemRepository;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly AppDbContext DbContext;

    public TodoItemRepository(AppDbContext DbContext)
    {
        this.DbContext = DbContext;
    }
    public async Task<List<TodoItem>> GetTodoItemsAsync()
    {
        var todoItems = await DbContext.TodoItems.ToListAsync();
        return todoItems;
    }

    public async Task<bool> AnyAsync(int Id)
    {
        var isExist = await DbContext.TodoItems.FindAsync(Id);
        return isExist != null;
    }

    public Task<int> GetTodoItemCount()
    {
        return DbContext.TodoItems.CountAsync();
    }

    public async Task<TodoItem> GetTodoItemAsync(int Id)
    {
        return await DbContext.TodoItems.FirstOrDefaultAsync(item => item.ItemId == Id);
    }

    public async Task<bool> CreateAsync(TodoItem TodoItem)
    {
        await DbContext.TodoItems.AddAsync(TodoItem);
        var result = await DbContext.SaveChangesAsync();
        return Convert.ToBoolean(result);
    }

    public async Task<bool> UpdateAsync(TodoItem TodoItem)
    {
        DbContext.TodoItems.Update(TodoItem);
        var result = await DbContext.SaveChangesAsync();
        return Convert.ToBoolean(result);
    }

    public async Task<TodoItem> GetAsync(int Id)
    {
        return await DbContext.TodoItems.FindAsync(Id);
    }
    public async Task<bool> DeleteAsync(int Id)
    {
        var TodoItem = await GetTodoItemAsync(Id);
        DbContext.TodoItems.Remove(TodoItem);
        var result = await DbContext.SaveChangesAsync();
        return Convert.ToBoolean(result);
    }
}