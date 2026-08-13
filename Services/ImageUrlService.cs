namespace silvaspoon.Services;

public class ImageUrlService : IImageUrlService
{
    private readonly HttpClient _http;

    public ImageUrlService(HttpClient http)
    {
        _http = http;
    }

    public string? GetImageUrl(string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            return null;

        if (Uri.IsWellFormedUriString(imagePath, UriKind.Absolute))
            return imagePath;

        return new Uri(_http.BaseAddress!, imagePath).ToString();
    }
}