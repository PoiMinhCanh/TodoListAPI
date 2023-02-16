using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;
using TodoListAPI.Repository.TodoItemRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add db
builder.Services.AddDbContext<AppDbContext>(
    options => {
        options.UseNpgsql(builder.Configuration.GetConnectionString("TodoListDb"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dj
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
