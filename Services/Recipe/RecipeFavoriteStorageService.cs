using Microsoft.JSInterop;

namespace silvaspoon.Services.Recipe;

public class RecipeFavoriteStorageService
{
    private readonly IJSRuntime _js;

    public RecipeFavoriteStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<bool> IsFavoriteAsync(int recipeId)
    {
        var value = await _js.InvokeAsync<string?>(
            "localStorage.getItem",
            $"recipe-favorite-{recipeId}");

        return value == "true";
    }

    public async Task SetFavoriteAsync(int recipeId)
    {
        await _js.InvokeVoidAsync(
            "localStorage.setItem",
            $"recipe-favorite-{recipeId}",
            "true");
    }

    public async Task RemoveFavoriteAsync(int recipeId)
    {
        await _js.InvokeVoidAsync(
            "localStorage.removeItem",
            $"recipe-favorite-{recipeId}");
    }
}