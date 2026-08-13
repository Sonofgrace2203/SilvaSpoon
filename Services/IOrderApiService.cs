using silvaspoon.Models;
using silvaspoon.Models.Pagination;

namespace silvaspoon.Services;

public interface IOrderApiService
{
    Task<List<Order>> GetOrdersAsync();
    Task<Order?> GetOrderAsync(int id);
    
    Task<PagedResult<Order>> GetOrdersAsync(
    int page,
    int pageSize,
    string? search = null,
    string? status = null);

    Task<OrderStatsDto> GetOrderStatsAsync();
    Task CreateOrderAsync(CreateOrderDto order);
    Task UpdateOrderStatusAsync(int id, string status);
    Task DeleteOrderAsync(int id);
    Task<List<TopMealDto>> GetTopMealsAsync();
}