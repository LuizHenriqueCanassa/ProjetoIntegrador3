namespace ProjetoIntegrador3.Application.Exceptions;

public class BookInUseException : Exception
{
    public BookInUseException(string? message)
    {
        Message = message;
    }

    public string? Message { get; set; }
}