using System.Net.Http.Json;
using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public class ContactSettingsApiService
    : IContactSettingsApiService
{
    private readonly HttpClient _http;

    public ContactSettingsApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ContactSetting?> GetAsync()
    {
        return await _http.GetFromJsonAsync<ContactSetting>(
            "api/settings/contact");
    }

    public async Task<ContactSetting?> UpdateAsync(
        ContactSetting setting)
    {
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(setting));
        
        var response = await _http.PutAsJsonAsync(
            "api/settings/contact",
            setting);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<ContactSetting>();
    }
}