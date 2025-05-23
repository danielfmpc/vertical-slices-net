using Microsoft.EntityFrameworkCore;
using ToDoVerticalSlice.Domain;
using ToDoVerticalSlice.Infrastructure.Context;

namespace ToDoVerticalSlice.Features.ToDos;

public class ToDoRepository(ToDoContext context)
{
    public async Task<List<ToDo>> GetAllAsync()
    {
        return await context.ToDos.ToListAsync();
    }
    
    public async Task<ToDo> GetByIdAsync(Guid id)
    {
        return await context.ToDos.FindAsync(id);
    }

    public async Task AddAsync(ToDo toDo)
    {
        context.ToDos.Add(toDo);
        await context.SaveChangesAsync();   
    }
    
    public async Task UpdateAsync(ToDo toDo)
    {
        context.ToDos.Update(toDo);
        await context.SaveChangesAsync();   
    }
    
}