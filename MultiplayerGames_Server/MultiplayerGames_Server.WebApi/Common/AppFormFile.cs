using System;
using MultiplayerGames_Server.Application.Abstractions;

namespace MultiplayerGames_Server.WebApi.Common;

public class AppFormFile : IAppFormFile
{
    private readonly IFormFile _formFile;

    public AppFormFile(IFormFile formFile)
    {
        _formFile = formFile;
    }

    public string Name => _formFile.Name;

    public string FileName => _formFile.FileName;

    public string ContentType => _formFile.ContentType;

    public long Length => _formFile.Length;

    public Stream OpenReadStream()
    {
        return _formFile.OpenReadStream();
    }
}
