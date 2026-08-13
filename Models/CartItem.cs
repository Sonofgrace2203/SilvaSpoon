namespace silvaspoon.Models;

public class CartItem
{
    public Meal Meal { get; set; } = new();

    public int Quantity { get; set; }
}