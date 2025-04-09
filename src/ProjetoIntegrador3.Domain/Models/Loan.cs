using ProjetoIntegrador3.Domain.Models.Enums;

namespace ProjetoIntegrador3.Domain.Models;

public class Loan
{
    public int Id { get; set; }
    public ApplicationUser User { get; set; }
    public Book Book { get; set; }
    public LoanStatus Status { get; set; } = LoanStatus.WAITING_WITHDRAWN;
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime DateReturned { get; set; }

    public bool isReturnLate()
    {
        return DateTime.Now >= ReturnDate;
    }
}