namespace silvaspoon.Models;

public class Recipe
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public string? Category { get; set; }

    public int Views { get; set; }

    public int FavoriteCount { get; set; }

    public string? ImageUrl { get; set; }

    public int PrepTime { get; set; }

    public int CookTime { get; set; }

    public int Servings { get; set; }

    public string Difficulty { get; set; } = string.Empty;

    public decimal Rating { get; set; }

    public int RatingCount { get; set; }

    public bool IsPublished { get; set; }

    public bool IsFeatured { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<RecipeIngredient> Ingredients { get; set; }
        = new();

    public List<RecipeInstruction> Instructions { get; set; }
        = new();
}