using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Domain.Models;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public string? Isbn { get; set; }
    public Genre? Genre { get; set; }
}