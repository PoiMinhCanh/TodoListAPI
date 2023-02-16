using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace TodoListAPI.Models;

public class AppDbContext : DbContext
{
    #region DbSet
    public DbSet<TodoItem> TodoItems{ get; set; }
    #endregion

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem { ItemId = 1, TaskName = "Learn About Docker", Description = "Learn About Docker Description" },
            new TodoItem { ItemId = 2, TaskName = "Learn About Git", Description = "Learn About Git Description" },
            new TodoItem { ItemId = 3, TaskName = "Learn About Microservices", Description = "Learn About Microservices Description" }
        );
    }
}
