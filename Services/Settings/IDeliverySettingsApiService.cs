using silvaspoon.Models.Settings;

namespace silvaspoon.Services.Settings;

public interface IDeliverySettingsApiService
{
    Task<DeliverySetting?> GetAsync();
    Task<DeliverySetting?> UpdateAsync(DeliverySetting setting);
}