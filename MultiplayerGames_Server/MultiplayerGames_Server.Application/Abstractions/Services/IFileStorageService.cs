using System;

namespace MultiplayerGames_Server.Application.Abstractions.Services;

public interface IFileStorageService
{
    public Task<string> SaveFileAsync(IAppFormFile file, string folderPath);
    public Task<string> SaveFileAsync(byte[] fileBytes, string folderPath, string filename);

    /// <summary>
    /// Saves a file to root subfolder and returns the relative path (e.g., "images/categories/filename.jpg")
    /// </summary>
    public Task<string> SaveFileToRootAsync(IAppFormFile file, string subfolder);

    /// <summary>
    /// Saves a bytes file to root subfolder and returns the relative path
    /// </summary>
    public Task<string> SaveFileToRootAsync(byte[] fileBytes, string subfolder, string filename);

    /// <summary>
    /// Deletes a file from root by relative path
    /// </summary>
    public Task DeleteFileFromRootAsync(string relativePath);
}
