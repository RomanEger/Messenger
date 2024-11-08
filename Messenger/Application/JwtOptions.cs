namespace Application;

public class JwtOptions
{
    public JwtOptions(string issuer, string audience, string secretKey)
    {
        Issuer = issuer;
        Audience = audience;
        SecretKey = secretKey;
    }

    public string Issuer { get; init; }

    public string Audience { get; init; }

    public string SecretKey { get; init; }
}