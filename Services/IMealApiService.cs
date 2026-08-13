using Microsoft.AspNetCore.Components.Forms;
using silvaspoon.Models;
using silvaspoon.Models.Pagination;

namespace silvaspoon.Services;

public interface IMealApiService
{
    Task UpdateOrderStatusAsync(int id, string status);
    Task<DashboardStats> GetDashboardStatsAsync();
    Task<List<MealStatsDto>> GetMealStatsAsync();
    Task<CreateOrderResponse> CreateOrderAsync(CreateOrderDto dto);
    Task<Order?> GetOrderAsync(int id);
    Task<List<Meal>> GetMealsAsync();
    
    // Task<PagedResult<Meal>> GetMealsAsync(int page, int pageSize, string? search = null, string? category = null);
    Task<PagedResult<Meal>> GetMealsAsync(
    int page,
    int pageSize,
    string? search = null,
    string? category = null,
    bool? isAvailable = null);

    Task<List<Order>> GetOrdersAsync();
    Task<Meal?> GetMealAsync(int id);
    Task CreateMealAsync(Meal meal);
    Task UpdateMealAsync(Meal meal);
    Task DeleteMealAsync(int id);
    Task DeleteOrderAsync(int id);
}





