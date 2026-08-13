namespace silvaspoon.Models.Settings;

public class ContactSetting
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = "";

    public string Email { get; set; } = "";

    public string Address { get; set; } = "";

    public List<BusinessHour> BusinessHours { get; set; } = new();
}