using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public interface IContactSettingsApiService
{
    Task<ContactSetting?> GetAsync();
    Task<ContactSetting?> UpdateAsync(ContactSetting setting);
}
