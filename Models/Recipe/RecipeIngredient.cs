namespace silvaspoon.Models;

public class RecipeIngredient
{
    public int Id { get; set; }

    public string Ingredient { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}