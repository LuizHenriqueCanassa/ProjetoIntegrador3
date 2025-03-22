namespace ProjetoIntegrador3.Infra.Identity.JWT;

public class AppJwtSettings
{
    public string? SecretKey { get; set; }
    public int Expiration { get; set; }
    public string? Issuer { get; set; }
    public List<string>? Audience { get; set; }
}