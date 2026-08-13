using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public interface IBusinessSettingsApiService
{
    Task<BusinessSetting?> GetAsync();
    Task<BusinessSetting?> UpdateAsync(BusinessSetting setting);
}
