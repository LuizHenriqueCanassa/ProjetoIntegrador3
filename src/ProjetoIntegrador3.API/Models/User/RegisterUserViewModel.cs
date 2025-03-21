using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador3.API.Models.User;

public class RegisterUserViewModel
{
    [DisplayName("Nome completo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string FullName { get; set; }
    
    [DisplayName("Email")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Email { get; set; }
    
    [DisplayName("Senha")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(20, MinimumLength = 10, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Password { get; set; }
    
    [DisplayName("Confirmar senha")]
    [Compare(nameof(Password), ErrorMessage = "As senhas não são iguais")]
    public string ConfirmPassword { get; set; }
    
    [DisplayName("Data de Nascimento")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }
    
    [DisplayName("Endereço")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public AddressUserViewModel Address { get; set; }
}