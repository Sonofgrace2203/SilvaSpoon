namespace silvaspoon.Models;

public class OrderStatsDto
{
    public int TotalOrders { get; set; }
    public int TodayOrders { get; set; }

    public int PendingOrders { get; set; }
    public int PreparingOrders { get; set; }
    public int DeliveredOrders { get; set; }

    public decimal TodayRevenue { get; set; }
    public decimal TotalRevenue { get; set; }
}