namespace silvaspoon.Models.Settings;

public class MealCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;
}