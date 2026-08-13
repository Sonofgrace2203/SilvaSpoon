using Microsoft.AspNetCore.Components.Forms;
using silvaspoon.Models;
using silvaspoon.Models.Pagination;
using System.Net.Http.Json;
namespace silvaspoon.Services;


public class MealApiService : IMealApiService
{
    private readonly HttpClient _http;

    public MealApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Meal>> GetMealsAsync()
    {
        return await _http.GetFromJsonAsync<List<Meal>>("api/meals") ?? new List<Meal>();
    }

    // public async Task<PagedResult<Meal>> GetMealsAsync(int page, int pageSize, string? search = null, string? category = null)
    public async Task<PagedResult<Meal>> GetMealsAsync(
    int page,
    int pageSize,
    string? search = null,
    string? category = null,
    bool? isAvailable = null)
    {
        var url = $"api/meals/paged?page={page}&pageSize={pageSize}";

        if (!string.IsNullOrWhiteSpace(search))
        {
            url += $"&search={Uri.EscapeDataString(search)}";
        }

        if (!string.IsNullOrWhiteSpace(category) &&
            category.ToLower() != "all")
        {
            url += $"&category={Uri.EscapeDataString(category)}";
        }

        if (isAvailable.HasValue)
        {
            url += $"&isAvailable={isAvailable.Value}";
        }

        // Console.WriteLine(url);

        return await _http.GetFromJsonAsync<PagedResult<Meal>>(url)
               ?? new PagedResult<Meal>();
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _http.GetFromJsonAsync<List<Order>>("api/orders")
               ?? new();
    }

    public async Task<Meal?> GetMealAsync(int id)
    {
        return await _http.GetFromJsonAsync<Meal>($"api/meals/{id}");
    }

    public async Task CreateMealAsync(Meal meal)
    {
        await _http.PostAsJsonAsync("api/meals", meal);
    }

    public async Task UpdateMealAsync(Meal meal)
    {
        await _http.PutAsJsonAsync($"api/meals/{meal.Id}", meal);
    }

    public async Task UpdateOrderStatusAsync(int id, string status)
    {
        await _http.PutAsJsonAsync(
            $"api/orders/{id}/status",
            new { Status = status });
    }

    public async Task DeleteMealAsync(int id)
    {
        await _http.DeleteAsync($"api/meals/{id}");
    }

    public async Task DeleteOrderAsync(int id)
    {
        await _http.DeleteAsync($"api/orders/{id}");
    }

    public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/orders", dto);

        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        response.EnsureSuccessStatusCode();

        return System.Text.Json.JsonSerializer.Deserialize<CreateOrderResponse>(
            body,
            new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
    }

    public async Task<Order?> GetOrderAsync(int id)
    {
        return await _http.GetFromJsonAsync<Order>($"api/orders/{id}");
    }

    public async Task<DashboardStats> GetDashboardStatsAsync()
    {
        return await _http.GetFromJsonAsync<DashboardStats>("api/dashboard/stats") ?? new DashboardStats();
    }

    public async Task<List<MealStatsDto>> GetMealStatsAsync()
    {
        return await _http.GetFromJsonAsync<List<MealStatsDto>>(
            "api/meals/stats") ?? new List<MealStatsDto>();
    }
}






