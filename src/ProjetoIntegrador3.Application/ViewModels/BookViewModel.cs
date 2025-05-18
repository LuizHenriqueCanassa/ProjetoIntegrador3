namespace ProjetoIntegrador3.Application.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Publisher { get; set; }
    public string? Isbn { get; set; }
    public string? Status { get; set; }
    public int? GenreId { get; set; }
    public string? Genre { get; set; }
}