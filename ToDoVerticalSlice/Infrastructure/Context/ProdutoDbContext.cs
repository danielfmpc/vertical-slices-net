using Microsoft.EntityFrameworkCore;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Infrastructure.Context;

public class ProdutoDbContext : DbContext
{
    public ProdutoDbContext(DbContextOptions options) :base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().HasKey(t => t.Id);
        base.OnModelCreating(modelBuilder);
    }
}