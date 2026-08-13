using System.ComponentModel.DataAnnotations;
using silvaspoon.Models.Settings;

public class BusinessSetting
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string BusinessName { get; set; } = "";

    [Required]
    [MaxLength(150)]
    public string Tagline { get; set; } = "";

    [Required]
    [MaxLength(1000)]
    public string AboutUs { get; set; } = "";

    public string? ImageUrl { get; set; }

    public List<BusinessFeature> Features { get; set; } = new();
}