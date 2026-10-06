using System;
using Microsoft.AspNetCore.Hosting;
using MultiplayerGames_Server.Application.Abstractions;
using MultiplayerGames_Server.Application.Abstractions.Services;

namespace MultiplayerGames_Server.Infrastructure.Services;

internal class FileStorageService : IFileStorageService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileStorageService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> SaveFileAsync(IAppFormFile file, string folderPath)
    {
        using var ms = new MemoryStream();
        await file.OpenReadStream().CopyToAsync(ms);
        byte[] bytes = ms.ToArray();

        return await SaveFileAsync(bytes, folderPath, file.FileName);
    }

    public async Task<string> SaveFileAsync(byte[] fileBytes, string folderPath, string filename)
    {
        // Ensure directory exists
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Generate unique filename if needed (to avoid overwrites)
        string uniqueFilename = _GenerateUniqueFilename(folderPath, filename);
        string fullPath = Path.Combine(folderPath, uniqueFilename);
        await File.WriteAllBytesAsync(fullPath, fileBytes);
        return fullPath;
    }

    public async Task<string> SaveFileToRootAsync(IAppFormFile file, string subfolder)
    {
        using var ms = new MemoryStream();
        await file.OpenReadStream().CopyToAsync(ms);
        byte[] bytes = ms.ToArray();

        return await SaveFileToRootAsync(bytes, subfolder, file.FileName);
    }

    public async Task<string> SaveFileToRootAsync(
        byte[] fileBytes,
        string subfolder,
        string filename
    )
    {
        string wwwrootPath =
            _webHostEnvironment.WebRootPath
            ?? Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot");

        // Ensure wwwroot exists
        if (!Directory.Exists(wwwrootPath))
        {
            Directory.CreateDirectory(wwwrootPath);
        }

        string folderPath = Path.Combine(wwwrootPath, subfolder);

        // Ensure subfolder exists
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Generate unique filename if needed (to avoid overwrites)
        string uniqueFilename = _GenerateUniqueFilename(folderPath, filename);
        string fullPath = Path.Combine(folderPath, uniqueFilename);

        await File.WriteAllBytesAsync(fullPath, fileBytes);

        // Return relative path (e.g., "images/categories/filename.jpg")
        return Path.Combine(subfolder, uniqueFilename).Replace("\\", "/");
    }

    public async Task DeleteFileFromRootAsync(string relativePath)
    {
        string wwwrootPath =
            _webHostEnvironment.WebRootPath
            ?? Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot");

        string fullPath = Path.Combine(wwwrootPath, relativePath);

        if (File.Exists(fullPath))
        {
            await Task.Run(() => File.Delete(fullPath));
        }
    }

    private string _GenerateUniqueFilename(string folderPath, string filename)
    {
        string nameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
        string extension = Path.GetExtension(filename);
        string fullPath = Path.Combine(folderPath, filename);

        if (!File.Exists(fullPath))
        {
            return filename;
        }

        int counter = 1;
        string newFilename;
        do
        {
            newFilename = $"{nameWithoutExtension}_{counter}{extension}";
            fullPath = Path.Combine(folderPath, newFilename);
            counter++;
        } while (File.Exists(fullPath));

        return newFilename;
    }
}
