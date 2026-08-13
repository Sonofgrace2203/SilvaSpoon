using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public interface IWhatsAppSettingsApiService
{
    Task<WhatsAppSetting?> GetAsync();
    Task<WhatsAppSetting?> UpdateAsync(
        WhatsAppSetting setting);
}