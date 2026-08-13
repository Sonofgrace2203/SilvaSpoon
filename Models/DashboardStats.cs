namespace silvaspoon.Models;

public class DashboardStats
{
    public int TotalMeals { get; set; }
    public int AvailableMeals { get; set; }
    public int UnavailableMeals { get; set; }
    public int FeaturedMeals { get; set; }

    public int TotalOrders { get; set; }
    public int TodayOrders { get; set; }
    public int PendingOrders { get; set; }
    public int PreparingOrders { get; set; }
    public int DeliveredOrders { get; set; }

    public int TotalCustomers { get; set; }

    public decimal PendingValue { get; set; }
    public decimal Revenue { get; set; }
}