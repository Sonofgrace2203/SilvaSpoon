namespace silvaspoon.Models.Settings;

public class BusinessHour
{
    public int Id { get; set; }

    public string Day { get; set; } = "";

    public string OpenTime { get; set; } = "";

    public string CloseTime { get; set; } = "";

    public bool IsClosed { get; set; }
}