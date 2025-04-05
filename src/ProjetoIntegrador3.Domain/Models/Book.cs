using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Domain.Models.Enums;

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
    public BookStatus Status { get; set; } = BookStatus.Available;
    public Genre? Genre { get; set; }
}