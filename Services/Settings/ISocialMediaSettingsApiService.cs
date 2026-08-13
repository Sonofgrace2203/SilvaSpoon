using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public interface ISocialMediaSettingsApiService
{
    Task<SocialMediaSetting?> GetAsync();
    Task<SocialMediaSetting?> UpdateAsync(SocialMediaSetting setting);
}