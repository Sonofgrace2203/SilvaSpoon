namespace silvaspoon.Models;

public class RecipeInstruction
{
    public int Id { get; set; }

    public int StepNumber { get; set; }

    public string Instruction { get; set; } = string.Empty;
}