using System;

namespace MultiplayerGames_Server.Application.Abstractions;

public interface IAppFormFile
{
    public string FileName { get; }
    public string ContentType { get; }
    public long Length { get; }

    Stream OpenReadStream();
}
