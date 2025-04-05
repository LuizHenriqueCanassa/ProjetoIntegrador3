namespace ProjetoIntegrador3.Application.Exceptions;

public class BookStatusException : Exception
{
    public string? Message { get; set; }
    
    public BookStatusException(string? message)
    {
        Message = message;
    }
}