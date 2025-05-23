using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ToDoVerticalSlice.Features;
using ToDoVerticalSlice.Features.Produtos.Controllers;
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

builder.Services.AddScoped<ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapProducts();
}



app.UseHttpsRedirection();

app.Run();
