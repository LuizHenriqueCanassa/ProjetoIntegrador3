namespace ProjetoIntegrador3.Application.Exceptions;

public class RegisterNotFoundException : Exception
{
    public string? Message { get; set; }
    
    public RegisterNotFoundException()
    {
        
    }

    public RegisterNotFoundException(string message)
    {
        Message = message;
    }
}