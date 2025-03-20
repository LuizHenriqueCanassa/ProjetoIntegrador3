namespace ProjetoIntegrador3.Infra.Identity.Models;

public class UserAddress
{
    public static string? StreetAddress { get; set; }
    public int StreetNumber { get; set; }
    public static string? City { get; set; }
    public static string? State { get; set; }
    public static string? Zip { get; set; }
}