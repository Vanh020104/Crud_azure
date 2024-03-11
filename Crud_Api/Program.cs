using Crud_Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("Todolist"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/products", async (TodoDb db) =>
    await db.Products.ToListAsync());


app.MapGet("/products/{id}", async (int id, TodoDb db) =>
    await db.Products.FindAsync(id)


        is Product toDo
        ? Results.Ok(toDo) : Results.NotFound());

app.MapPost("/products", async (Product todo, TodoDb db) =>
{
    db.Products.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/products/{todo.ProductId}", todo);
});

app.MapPut("/products/{id}", async (int id, Product inputTodo, TodoDb db) =>
{
    var todo = await db.Products.FindAsync(id)

;
    if (todo == null) return Results.NotFound();

    todo.ProductId = inputTodo.ProductId;
    todo.ProductName = inputTodo.ProductName;
    todo.Description = inputTodo.Description;
    todo.Price = inputTodo.Price;
    todo.Qty = inputTodo.Qty;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/products/{id}", async (int id, TodoDb db) =>
{
    if (await db.Products.FindAsync(id)

 is Product todo)
    {
        db.Products.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }
    return Results.NotFound();
});
app.Run();