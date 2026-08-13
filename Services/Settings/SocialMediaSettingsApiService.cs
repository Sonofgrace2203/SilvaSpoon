using System.Net.Http.Json;
using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public class SocialMediaSettingsApiService
    : ISocialMediaSettingsApiService
{
    private readonly HttpClient _http;

    public SocialMediaSettingsApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<SocialMediaSetting?> GetAsync()
    {
        return await _http.GetFromJsonAsync<SocialMediaSetting>(
            "api/settings/social");
    }

    public async Task<SocialMediaSetting?> UpdateAsync(
        SocialMediaSetting setting)
    {
        var response = await _http.PutAsJsonAsync(
            "api/settings/social",
            setting);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<SocialMediaSetting>();
    }
}