using Microsoft.JSInterop;

namespace silvaspoon.Services.Recipe;

public class RecipeRatingStorageService
{
    private readonly IJSRuntime _js;

    public RecipeRatingStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<bool> HasRatedAsync(int recipeId)
    {
        var value = await _js.InvokeAsync<string?>(
            "localStorage.getItem",
            $"recipe-rated-{recipeId}");

        return value == "true";
    }

    public async Task SaveRatingAsync(int recipeId, int rating)
    {
        await _js.InvokeVoidAsync(
            "localStorage.setItem",
            $"recipe-rated-{recipeId}",
            rating.ToString());
    }

    public async Task<int?> GetRatingAsync(int recipeId)
    {
        var value = await _js.InvokeAsync<string?>(
            "localStorage.getItem",
            $"recipe-rated-{recipeId}");

        if (int.TryParse(value, out var rating))
            return rating;

        return null;
    }
}