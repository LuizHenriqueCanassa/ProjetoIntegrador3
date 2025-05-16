using ProjetoIntegrador3.Application.ViewModels.User;

namespace ProjetoIntegrador3.Application.ViewModels;

public class LoanViewModel
{
    public int Id { get; set; }
    public BookViewModel Book { get; set; }
    public UserViewModel User { get; set; }
    public string Status { get; set; }
    public string LoanDate { get; set; }
    public string ReturnDate { get; set; }
    public string DateReturned { get; set; }
    public bool isReturnLate { get; set; }
}