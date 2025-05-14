using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador3.Application.ViewModels;

public class CreateUpdateGenreViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "O Campo {0} deve conter entre {2} e {1} caracteres")]
    public string? Name { get; set; }
    
    [Required]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "O Campo {0} deve conter entre {2} e {1} caracteres")]
    public string? Description { get; set; }

    public bool? IsActive { get; set; } = true;
}