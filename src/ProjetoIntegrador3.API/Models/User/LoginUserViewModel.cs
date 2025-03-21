using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador3.API.Models.User;

public class LoginUserViewModel
{
    [DisplayName("Email")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
    public string Email { get; set; }
    
    [DisplayName("Senha")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Password { get; set; }
}