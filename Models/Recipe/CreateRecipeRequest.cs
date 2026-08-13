namespace silvaspoon.Models;

public class CreateRecipeRequest
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public int PrepTime { get; set; }

    public int CookTime { get; set; }

    public int Servings { get; set; }

    public string Difficulty { get; set; } = "Medium";

    public bool IsPublished { get; set; } = true;

    public bool IsFeatured { get; set; }

    public List<string> Ingredients { get; set; } = new();

    public List<string> Instructions { get; set; } = new();

    public string? Category { get; set; }
}