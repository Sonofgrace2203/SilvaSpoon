// namespace silvaspoon.Models;

// public class MealStatsDto
// {
//     public int TotalRiceDishes { get; set; }
//     public int TotalSwallow { get; set; }
//     public int TotalSoups { get; set; }
//     public int TotalVegetables { get; set; }
//     public int TotalDrinks { get; set; }
//     public int TotalSnacks { get; set; }
// }

namespace silvaspoon.Models;

public class MealStatsDto
{
    public string Category { get; set; } = string.Empty;
    public int Count { get; set; }
}