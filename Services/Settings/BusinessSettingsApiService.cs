using System.Net.Http.Json;
using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public class BusinessSettingsApiService
    : IBusinessSettingsApiService
{
    private readonly HttpClient _http;

    public BusinessSettingsApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<BusinessSetting?> GetAsync()
    {
        return await _http.GetFromJsonAsync<BusinessSetting>(
            "api/settings/business");
    }

    public async Task<BusinessSetting?> UpdateAsync(
        BusinessSetting setting)
    {   
        var response = await _http.PutAsJsonAsync(
            "api/settings/business",
            setting);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<BusinessSetting>();
    }
}