using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public interface IMealSettingsApiService
{
    Task<List<MealCategory>> GetAsync();

    Task<List<MealCategory>> UpdateAsync(
        List<MealCategory> categories);
}