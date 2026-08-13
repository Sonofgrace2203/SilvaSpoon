using silvaspoon.Models;
using silvaspoon.Models.Pagination;
using RecipeModel = silvaspoon.Models.Recipe;

namespace silvaspoon.Services;

public interface IRecipeApiService
{
    Task<List<RecipeModel>> GetRecipesAsync();

    Task<RecipeModel?> GetRecipeAsync(int id);

    Task<RecipeModel?> CreateRecipeAsync(RecipeModel recipe);

    Task<RecipeModel?> UpdateRecipeAsync(int id, RecipeModel recipe);

    Task<bool> DeleteRecipeAsync(int id);

    Task<RecipeStats?> GetRecipeStatsAsync();

    Task<PagedResult<RecipeModel>> GetPagedRecipesAsync(
    int page,
    int pageSize,
    string? search = null,
    string? category = null);

    Task<int?> AddFavoriteAsync(int recipeId);

    Task<int?> RemoveFavoriteAsync(int recipeId);

    Task<RecipeRatingResult?> AddRatingAsync(int recipeId, int rating);
}