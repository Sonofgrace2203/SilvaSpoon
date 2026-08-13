using System.ComponentModel.DataAnnotations;

namespace silvaspoon.Models;

public class Meal
{
    public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
    [Range(1, 1000000, ErrorMessage = "Price must be greater than zero.")] public decimal Price { get; set; }
    [Required] public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public AvailabilityStatus Availability { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; }
}