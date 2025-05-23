using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ToDoVerticalSlice.Features.Produtos;
using ToDoVerticalSlice.Features.Produtos.Controllers;
using ToDoVerticalSlice.Features.ToDos;
using ToDoVerticalSlice.Features.ToDos.Controller;
using ToDoVerticalSlice.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));


builder.Services.AddDbContext<ProdutoDbContext>(opt =>
{
    opt
        .UseInMemoryDatabase("VerticalSliceApiProdutoDb")
        .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
});

builder.Services.AddDbContext<ToDoContext>(opt =>
{
    opt
        .UseInMemoryDatabase("VerticalSliceApiProdutoDb")
        .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
});

builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<ToDoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapProducts();
    app.MapToDo();
}



app.UseHttpsRedirection();

app.Run();
