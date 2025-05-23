namespace ToDoVerticalSlice.Domain;

public class Produto
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public Produto(string name, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        CreatedAt = DateTime.UtcNow;
    }
    
    public void Update(string name, decimal preco)
    {
        Name = name;
        Price = preco;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}