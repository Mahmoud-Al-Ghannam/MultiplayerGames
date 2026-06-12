using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Infrastructure.Options;

namespace MultiplayerGames_Server.Infrastructure.Services;

internal class GenerateTokenService : IGenerateTokenService
{
    private readonly JwtOptions _jwtOption;

    public GenerateTokenService(IOptions<JwtOptions> jwtOption)
    {
        _jwtOption = jwtOption.Value;
    }

    public Task<string> GenerateAccessTokenAsync(User user, CancellationToken cancellationToken)
    {
        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Username),
        ];

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = _jwtOption.Audience,
            Issuer = _jwtOption.Issuer,
            Expires = DateTime.Now.AddMinutes(_jwtOption.LifeTimeMin),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Key)),
                SecurityAlgorithms.HmacSha256
            ),
            Subject = new ClaimsIdentity(claims),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        string accessToken = tokenHandler.WriteToken(token);
        return Task.FromResult(accessToken);
    }
}
