using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hangfire.Dashboard;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Infrastructure.Options;

namespace MultiplayerGames_Server.WebApi.Hangfire;

public class MyHangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    private readonly JwtOptions _jwtOptions;

    public MyHangfireAuthorizationFilter(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public bool Authorize(DashboardContext context)
    {
        // In a real app, check if the user is an Admin
        var httpContext = context.GetHttpContext();
        string token = "";
        // 1. Check if token is passed via URL parameter (?token=xxx)
        if (httpContext.Request.Query.TryGetValue("access_token", out var queryToken))
        {
            token = queryToken.FirstOrDefault() ?? string.Empty;

            // Store in secure cookie so subsequent sub-requests work
            httpContext.Response.Cookies.Append(
                "cookie-jwt",
                token,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Set to true for HTTPS (MonsterASP)
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(_jwtOptions.LifeTimeMin),
                }
            );
        }
        // 2. Otherwise, check if token is already saved in the cookie
        else if (httpContext.Request.Cookies.TryGetValue("cookie-jwt", out var cookieToken))
        {
            token = cookieToken;
        }

        if (string.IsNullOrEmpty(token))
            return false;

        var user = GetPrincipalFromAccessToken(token);
        return user?.Identity?.IsAuthenticated ?? false;
    }

    private ClaimsPrincipal? GetPrincipalFromAccessToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtOptions.Key);

        try
        {
            // Configure validation parameters (must match how you issued the token).
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true, // Ensures the token is not expired.
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero, // Optional: removes the default 5-minute tolerance.
            };

            // Validate the token. If invalid, this throws an exception.
            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

            return principal;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
