namespace ProjetoIntegrador3.Infra.Identity.Models;

public class UserAddress
{
    public int Id { get; set; }
    public string StreetAddress { get; set; }
    public int StreetNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}