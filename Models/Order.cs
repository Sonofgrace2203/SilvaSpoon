namespace silvaspoon.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string DeliveryAddress { get; set; } = "";
    public string? Note { get; set; }
    public string Status { get; set; } = "";
    public decimal TotalAmount { get; set; }
    public DateTime OrderedAt { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
}