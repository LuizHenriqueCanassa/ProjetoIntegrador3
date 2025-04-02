namespace ProjetoIntegrador3.Domain.Models;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }
    public IEnumerable<Book>? Books { get; set; }
}