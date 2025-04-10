namespace ProjetoIntegrador3.Application.Exceptions;

public class LoanNotFoundException : Exception
{
    public string? Message { get; set; }

    public LoanNotFoundException(string? message)
    {
        Message = message;
    }
}