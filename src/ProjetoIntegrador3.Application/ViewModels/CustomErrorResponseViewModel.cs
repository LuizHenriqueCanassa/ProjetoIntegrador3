namespace ProjetoIntegrador3.Application.ViewModels;

public class CustomErrorResponseViewModel
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Uri { get; set; }
    public string? DateOcurrence { get; set; }
}