using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
public class AuthServices : IJwtService
{
    private readonly string key;
    private readonly string issuer;
    private readonly string audience;
    private readonly double durationInMinutes;

    public AuthServices(IConfiguration configuration)
    {
        key = configuration["Authentication:Secret"];
        issuer = configuration["Authentication:ValidIssuer"];
        audience = configuration["Authentication:ValidAudience"];
        durationInMinutes = Convert.ToDouble(configuration["Authentication:TokenExpiryTimeInHour"]);
    }

    public string GenerateToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.UtcNow.AddMinutes(durationInMinutes),
            signingCredentials: credentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}
