using System;

namespace MultiplayerGames_Server.WebApi.Helpers;

public class FileUrlHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FileUrlHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? WrapPath(string? relativePath)
    {
        if (string.IsNullOrWhiteSpace(relativePath))
            return null;

        if (Uri.TryCreate(relativePath, UriKind.Absolute, out _))
            return relativePath;

        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
            return relativePath;

        var request = httpContext.Request;
        var host = request.Host.Value;
        if (string.IsNullOrWhiteSpace(host))
            return relativePath;

        var normalizedPath = relativePath.Replace("\\", "/").TrimStart('/');
        var path = string.IsNullOrEmpty(request.PathBase) ? "" : $"/{request.PathBase}";
        return $"{request.Scheme}://{host}{path}/{normalizedPath}";
    }
}
