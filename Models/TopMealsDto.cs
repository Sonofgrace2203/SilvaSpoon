namespace silvaspoon.Models;

public class TopMealDto
{
    public int MealId { get; set; }
    public string Name { get; set; } = "";
    public string? ImageUrl { get; set; }
    public int OrderCount { get; set; }
}