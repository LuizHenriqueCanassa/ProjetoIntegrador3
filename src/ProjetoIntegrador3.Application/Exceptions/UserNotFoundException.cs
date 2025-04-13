namespace ProjetoIntegrador3.Application.Exceptions;

public class UserNotFoundException : Exception
{
    public string? Message { get; set; }

    public UserNotFoundException(string? message)
    {
        Message = message;
    }
}