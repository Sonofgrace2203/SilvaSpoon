namespace silvaspoon.Models.Settings;

public class DeliverySetting
{
    public int Id { get; set; }

    public decimal DeliveryFee { get; set; }

    public decimal FreeDeliveryAbove { get; set; }

    public string EstimatedDeliveryTime { get; set; } = "";

    public List<DeliveryArea> Areas { get; set; } = new();
}