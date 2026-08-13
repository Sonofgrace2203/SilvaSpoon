using System.Net.Http.Json;
using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public class WhatsAppSettingsApiService
    : IWhatsAppSettingsApiService
{
    private readonly HttpClient _http;

    public WhatsAppSettingsApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<WhatsAppSetting?> GetAsync()
    {
        return await _http.GetFromJsonAsync<WhatsAppSetting>(
            "api/settings/whatsapp");
    }

    public async Task<WhatsAppSetting?> UpdateAsync(
        WhatsAppSetting setting)
    {
        var response = await _http.PutAsJsonAsync(
            "api/settings/whatsapp",
            setting);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<WhatsAppSetting>();
    }
}