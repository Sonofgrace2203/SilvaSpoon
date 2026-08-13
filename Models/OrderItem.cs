namespace silvaspoon.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int MealId { get; set; }
    public Meal? Meal { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}



