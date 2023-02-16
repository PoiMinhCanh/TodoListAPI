using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;
using TodoListAPI.Repository.TodoItemRepository;

namespace TodoListAPI.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class TodoItemController : ControllerBase
{
    private readonly ITodoItemRepository TodoItemRepository;

    public TodoItemController(ITodoItemRepository TodoItemRepository)
    {
        this.TodoItemRepository = TodoItemRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTodoItems()
    {
        var todoItems = await TodoItemRepository.GetTodoItemsAsync();
        if (todoItems == null)
        {
            return NotFound();
        }
        return Ok(todoItems);
    }

    [HttpGet]
    public async Task<IActionResult> CheckId(int Id)
    {
        var isExist = await TodoItemRepository.AnyAsync(Id);
        return Ok(isExist);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodoItemCount()
    {
        var count = await TodoItemRepository.GetTodoItemCount();
        return Ok(count);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodoItemById(int Id)
    {
        var todoItem = await TodoItemRepository.GetTodoItemAsync(Id);
        if (todoItem == null)
        {
            return NotFound();
        }
        return Ok(todoItem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoItem(TodoItem TodoItem)
    {
        var isExist = await TodoItemRepository.AnyAsync(TodoItem.ItemId);
        if (isExist)
        {
            return BadRequest("TodoItem is exist!");
        }

        await TodoItemRepository.CreateAsync(TodoItem);
        return Ok("Create Success!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTodoItem(TodoItem TodoItem)
    {
        var isExist = await TodoItemRepository.AnyAsync(TodoItem.ItemId);
        if (!isExist)
        {
            return NotFound();
        }

        await TodoItemRepository.UpdateAsync(TodoItem);
        return Ok("Update Success!");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTodoItem(int Id)
    {
        await TodoItemRepository.DeleteAsync(Id);
        return Ok("Delete Success!");
    }
}
