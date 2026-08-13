using System.Net.Http.Json;
using silvaspoon.Models;
using silvaspoon.Models.Pagination;
using RecipeModel = silvaspoon.Models.Recipe;

namespace silvaspoon.Services;

public class RecipeApiService : IRecipeApiService
{
    private readonly HttpClient _http;

    public RecipeApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<RecipeModel>> GetRecipesAsync()
    {
        return await _http.GetFromJsonAsync<List<RecipeModel>>(
            "api/recipes")
            ?? new List<RecipeModel>();
    }

    public async Task<RecipeModel?> GetRecipeAsync(int id)
    {
        return await _http.GetFromJsonAsync<RecipeModel>(
            $"api/recipes/{id}");
    }

    public async Task<RecipeModel?> CreateRecipeAsync(RecipeModel recipe)
    {
        var request = new CreateRecipeRequest
        {
            Title = recipe.Title,
            Description = recipe.Description,
            ImageUrl = recipe.ImageUrl,
            PrepTime = recipe.PrepTime,
            CookTime = recipe.CookTime,
            Servings = recipe.Servings,
            Difficulty = recipe.Difficulty,
            IsPublished = recipe.IsPublished,
            IsFeatured = recipe.IsFeatured,
            Category = recipe.Category,

            Ingredients = recipe.Ingredients
                .OrderBy(x => x.DisplayOrder)
                .Select(x => x.Ingredient)
                .ToList(),

            Instructions = recipe.Instructions
                .OrderBy(x => x.StepNumber)
                .Select(x => x.Instruction)
                .ToList()
        };

        var response = await _http.PostAsJsonAsync(
            "api/recipes",
            request);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<RecipeModel>();
    }

    public async Task<RecipeModel?> UpdateRecipeAsync(
        int id,
        RecipeModel recipe)
    {
        var request = new UpdateRecipeRequest
        {
            Title = recipe.Title,
            Description = recipe.Description,
            ImageUrl = recipe.ImageUrl,
            PrepTime = recipe.PrepTime,
            CookTime = recipe.CookTime,
            Servings = recipe.Servings,
            Difficulty = recipe.Difficulty,
            IsPublished = recipe.IsPublished,
            IsFeatured = recipe.IsFeatured,
            Category = recipe.Category,

            Ingredients = recipe.Ingredients
                .OrderBy(x => x.DisplayOrder)
                .Select(x => x.Ingredient)
                .ToList(),

            Instructions = recipe.Instructions
                .OrderBy(x => x.StepNumber)
                .Select(x => x.Instruction)
                .ToList()
        };

        var response = await _http.PutAsJsonAsync(
            $"api/recipes/{id}",
            request);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<RecipeModel>();
    }

    public async Task<bool> DeleteRecipeAsync(int id)
    {
        var response = await _http.DeleteAsync(
            $"api/recipes/{id}");

        return response.IsSuccessStatusCode;
    }

    public async Task<PagedResult<RecipeModel>> GetPagedRecipesAsync(
    int page,
    int pageSize,
    string? search = null,
    string? category = null)
    {
        var url = $"api/Recipes/paged?page={page}&pageSize={pageSize}";

        if (!string.IsNullOrWhiteSpace(search))
        {
            url += $"&search={Uri.EscapeDataString(search)}";
        }

        if (!string.IsNullOrWhiteSpace(category) &&
            category.ToLower() != "all")
        {
            url += $"&category={Uri.EscapeDataString(category)}";
        }

        Console.WriteLine($"Recipe API URL: {url}");

        return await _http.GetFromJsonAsync<PagedResult<RecipeModel>>(url)
               ?? new PagedResult<RecipeModel>();
    }

    public async Task<RecipeStats?> GetRecipeStatsAsync()
    {
        var url = $"api/recipes/stats?_={DateTime.UtcNow.Ticks}";

        return await _http.GetFromJsonAsync<RecipeStats>(url)
               ?? new RecipeStats();
    }

    public async Task<int?> AddFavoriteAsync(int recipeId)
    {
        var response = await _http.PostAsync(
            $"api/recipes/{recipeId}/favorite",
            null);

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content
            .ReadFromJsonAsync<FavoriteResponse>();

        return result?.FavoriteCount;
    }

    public async Task<int?> RemoveFavoriteAsync(int recipeId)
    {
        var response = await _http.DeleteAsync(
            $"api/recipes/{recipeId}/favorite");

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content
            .ReadFromJsonAsync<FavoriteResponse>();

        return result?.FavoriteCount;
    }

    public async Task<RecipeRatingResult?> AddRatingAsync(
    int recipeId,
    int rating)
    {
        var response = await _http.PostAsJsonAsync(
            $"api/recipes/{recipeId}/rating",
            rating);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content
            .ReadFromJsonAsync<RecipeRatingResult>();
    }

    private class FavoriteResponse
    {
        public int Id { get; set; }

        public int FavoriteCount { get; set; }
    }
}