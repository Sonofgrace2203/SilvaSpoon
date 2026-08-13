using silvaspoon.Models.Settings;

namespace silvaspoon.Services;

public class BusinessSettingsState
{
    public BusinessSetting Current { get; private set; } = new();

    public event Action? OnChange;

    public void Set(BusinessSetting setting)
    {
        Current = setting;
        OnChange?.Invoke();
    }
}