namespace ProjetoIntegrador3.Application.Exceptions;

public class LoanStatusException : Exception
{
    public string? Message { get; set; }

    public LoanStatusException(string? message)
    {
        Message = message;
    }
}