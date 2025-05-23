using Microsoft.EntityFrameworkCore;
using ToDoVerticalSlice.Domain;
using ToDoVerticalSlice.Infrastructure.Context;

namespace ToDoVerticalSlice.Features;

public class ProdutoRepository(ProdutoDbContext context)
{
    public async Task<List<Produto>> GetAllAsync()
    {
        return await context.Produtos.ToListAsync();
    }

    public async Task<Produto> GetByIdAsync(Guid id)
    {
        return await context.Produtos.FindAsync(id);    
    }

    public async Task AddAsync(Produto produto)
    {
        await context.Produtos.AddAsync(produto);   
        await context.SaveChangesAsync();   
    }

    public async Task UpdateAsync(Produto produto)
    {
        context.Produtos.Update(produto);   
        await context.SaveChangesAsync();   
    }

    public async Task DeleteAsync(Produto produto)
    {
        context.Produtos.Remove(produto);   
        await context.SaveChangesAsync();  
    }
}