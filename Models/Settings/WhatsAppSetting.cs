namespace silvaspoon.Models.Settings;

public class WhatsAppSetting
{
    public int Id { get; set; }

    public string Number { get; set; } = string.Empty;

    public string GreetingMessage { get; set; } = string.Empty;

    public string ThankYouMessage { get; set; } = string.Empty;
}