namespace ProjetoIntegrador3.Application.ViewModels;

public class GenreViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }
}