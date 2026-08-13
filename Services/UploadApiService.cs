using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace silvaspoon.Services.Upload;

public class UploadApiService : IUploadApiService
{
    private readonly HttpClient _http;

    public UploadApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string?> UploadImageAsync(
        IBrowserFile file,
        string folder)
    {
        using var content = new MultipartFormDataContent();

        var stream = file.OpenReadStream(10 * 1024 * 1024);

        var fileContent = new StreamContent(stream);

        fileContent.Headers.ContentType =
            new MediaTypeHeaderValue(file.ContentType);

        content.Add(
            fileContent,
            "file",
            file.Name);

        var response = await _http.PostAsync(
            $"api/upload?folder={folder}",
            content);

        if (!response.IsSuccessStatusCode)
            return null;

        var result =
            await response.Content.ReadFromJsonAsync<UploadResponse>();

        if (result?.ImageUrl == null)
            return null;

        return result.ImageUrl;
    }

    private class UploadResponse
    {
        public string? ImageUrl { get; set; }
    }
}