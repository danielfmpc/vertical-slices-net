using Microsoft.EntityFrameworkCore;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Infrastructure.Context;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<ToDo> ToDos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>().HasKey(t => t.Id);
        base.OnModelCreating(modelBuilder);
    }
}