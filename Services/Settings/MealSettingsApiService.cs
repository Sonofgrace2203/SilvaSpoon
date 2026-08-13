using System.Net.Http.Json;
using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public class MealSettingsApiService
    : IMealSettingsApiService
{
    private readonly HttpClient _http;

    public MealSettingsApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<MealCategory>> GetAsync()
    {
        return await _http.GetFromJsonAsync<List<MealCategory>>(
                   "api/settings/meals")
               ?? new();
    }

    public async Task<List<MealCategory>> UpdateAsync(
        List<MealCategory> categories)
    {
        var response = await _http.PutAsJsonAsync(
            "api/settings/meals",
            categories);

        response.EnsureSuccessStatusCode();

        return await response.Content
                   .ReadFromJsonAsync<List<MealCategory>>()
               ?? new();
    }
}