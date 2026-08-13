using System.Net.Http.Json;
using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public class DeliverySettingsApiService
    : IDeliverySettingsApiService
{
    private readonly HttpClient _http;

    public DeliverySettingsApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<DeliverySetting?> GetAsync()
    {
        return await _http.GetFromJsonAsync<DeliverySetting>(
            "api/settings/delivery");
    }

    public async Task<DeliverySetting?> UpdateAsync(
        DeliverySetting setting)
    {
        var response = await _http.PutAsJsonAsync(
            "api/settings/delivery",
            setting);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<DeliverySetting>();
    }
}