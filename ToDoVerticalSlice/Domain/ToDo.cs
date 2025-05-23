namespace ToDoVerticalSlice.Domain;
public class ToDo
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ToDo(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        Done = false;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateTitle(string title)
    {
        Title = title;
        UpdatedAt = DateTime.UtcNow;
    } 
    
    public void UpdateDone(bool done)
    {
        Done = done;
        UpdatedAt = DateTime.UtcNow;
    }
    
    
}