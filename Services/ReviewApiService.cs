using System.Net.Http.Json;
using silvaspoon.Models;
using silvaspoon.Models.Pagination;

namespace silvaspoon.Services;

public class ReviewApiService : IReviewApiService
{
    private readonly HttpClient _http;

    public ReviewApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Review>> GetReviewsAsync()
    {
        return await _http.GetFromJsonAsync<List<Review>>("api/reviews")
               ?? new List<Review>();
    }

    public async Task<Review?> GetReviewAsync(int id)
    {
        return await _http.GetFromJsonAsync<Review>($"api/reviews/{id}");
    }

    public async Task<Review> CreateReviewAsync(Review review)
    {
        var response = await _http.PostAsJsonAsync("api/reviews", review);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Review>()
               ?? new Review();
    }

    public async Task UpdateReviewAsync(int id, Review review)
    {
        var response =
            await _http.PutAsJsonAsync($"api/reviews/{id}", review);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteReviewAsync(int id)
    {
        var response =
            await _http.DeleteAsync($"api/reviews/{id}");

        response.EnsureSuccessStatusCode();
    }

    public async Task<PagedResult<Review>> GetReviewsAsync(
    int page,
    int pageSize,
    string? search = null,
    bool? isPublished = null)
    {
        var url = $"api/reviews/paged?page={page}&pageSize={pageSize}";

        if (!string.IsNullOrWhiteSpace(search))
            url += $"&search={Uri.EscapeDataString(search)}";

        if (isPublished.HasValue)
            url += $"&isPublished={isPublished.Value}";

        return await _http.GetFromJsonAsync<PagedResult<Review>>(url)
               ?? new PagedResult<Review>();
    }
}