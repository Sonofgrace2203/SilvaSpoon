namespace silvaspoon.Models;
using System.ComponentModel.DataAnnotations;

public class Review
{
    public int Id { get; set; }
    [Required] [StringLength(50)] public string CustomerName { get; set; } = "";
    public string Position { get; set; } = "";
    [Required] [StringLength(500, MinimumLength = 15)] public string Comment { get; set; } = "";
    [Range(1,5)] public int Rating { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; }
}