using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MultiplayerGames_Server.Application.Abstractions.Services;

namespace MultiplayerGames_Server.Infrastructure.Services;

internal class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetUsername()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext?.User?.Identity?.IsAuthenticated != true)
        {
            return null;
        }

        return httpContext.User.FindFirst(ClaimTypes.Name)?.Value
            ?? httpContext.User.FindFirst("name")?.Value;
    }

    public string? GetUserId()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext?.User?.Identity?.IsAuthenticated != true)
        {
            return null;
        }

        var userId =
            httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? httpContext.User.FindFirst("sub")?.Value
            ?? httpContext.User.FindFirst("nameid")?.Value;

        return userId;
    }

    public bool IsAuthenticated()
    {
        return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true;
    }
}
