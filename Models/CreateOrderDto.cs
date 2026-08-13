using System.ComponentModel.DataAnnotations;

namespace silvaspoon.Models;

public class CreateOrderDto
{
    [Required] public string CustomerName { get; set; } = "";
    [Required] public string PhoneNumber { get; set; } = "";
    [Required] public string DeliveryAddress { get; set; } = "";
    public string? Note { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}




