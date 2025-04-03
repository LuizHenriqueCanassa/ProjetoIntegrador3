using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador3.Application.ViewModels;

public class CreateUpdateBookViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "O Campo {0} deve conter entre {2} e {1} caracteres")]
    public string? Title { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "O Campo {0} deve conter entre {2} e {1} caracteres")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "O Campo {0} deve conter entre {2} e {1} caracteres")]
    public string? ImageUrl { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "O Campo {0} deve conter entre {2} e {1} caracteres")]
    public string? Publisher { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? PublishDate { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "O Campo {0} deve conter {1} caracteres")]
    public string? Isbn { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int GenreId { get; set; }
}