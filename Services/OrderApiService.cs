using System.Net.Http.Json;
using silvaspoon.Models;
using silvaspoon.Models.Pagination;

namespace silvaspoon.Services;

public class OrderApiService : IOrderApiService
{
    private readonly HttpClient _http;

    public OrderApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        var response = await _http.GetAsync("api/orders");

        var json = await response.Content.ReadAsStringAsync();

        Console.WriteLine(json);

        response.EnsureSuccessStatusCode();

        return System.Text.Json.JsonSerializer.Deserialize<List<Order>>(
            json,
            new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new();
    }

    public async Task<Order?> GetOrderAsync(int id)
    {
        return await _http.GetFromJsonAsync<Order>($"api/orders/{id}");
    }

    public async Task CreateOrderAsync(CreateOrderDto order)
    {
        await _http.PostAsJsonAsync("api/orders", order);
    }

    public async Task UpdateOrderStatusAsync(int id, string status)
    {
        await _http.PutAsJsonAsync(
            $"api/orders/{id}/status",
            new { status });
    }

    public async Task DeleteOrderAsync(int id)
    {
        await _http.DeleteAsync($"api/orders/{id}");
    }

    public async Task<List<TopMealDto>> GetTopMealsAsync()
    {
        return await _http.GetFromJsonAsync<List<TopMealDto>>(
                   "api/orders/top-meals")
               ?? new();
    }

    public async Task<PagedResult<Order>> GetOrdersAsync(
    int page,
    int pageSize,
    string? search = null,
    string? status = null)
    {
        var url = $"api/orders/paged?page={page}&pageSize={pageSize}";

        if (!string.IsNullOrWhiteSpace(search))
        {
            url += $"&search={Uri.EscapeDataString(search)}";
        }

        if (!string.IsNullOrWhiteSpace(status) &&
            status.ToLower() != "all")
        {
            url += $"&status={Uri.EscapeDataString(status)}";
        }

        Console.WriteLine(url);

        return await _http.GetFromJsonAsync<PagedResult<Order>>(url)
               ?? new();
    }

    public async Task<OrderStatsDto> GetOrderStatsAsync()
    {
        return await _http.GetFromJsonAsync<OrderStatsDto>(
            "api/orders/stats")
            ?? new OrderStatsDto();
    }
}