using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador3.Application.ViewModels.User;

public class AddressUserViewModel
{
    [DisplayName("Endereço")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string StreetAddress { get; set; }
    
    [DisplayName("Numero")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int StreetNumber { get; set; }
    
    [DisplayName("Cidade")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string City { get; set; }
    
    [DisplayName("Estado")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter apenas 2 caracteres")]
    public string State { get; set; }
    
    [DisplayName("CEP")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "O campo {0} deve ter apenas 11 caracteres")]
    public string Zip { get; set; }
}