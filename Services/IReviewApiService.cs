using silvaspoon.Models;
using silvaspoon.Models.Pagination;

namespace silvaspoon.Services;

public interface IReviewApiService
{
    Task<List<Review>> GetReviewsAsync();

    Task<PagedResult<Review>> GetReviewsAsync(
    int page,
    int pageSize,
    string? search = null,
    bool? isPublished = null);

    Task<Review?> GetReviewAsync(int id);
    Task<Review> CreateReviewAsync(Review review);
    Task UpdateReviewAsync(int id, Review review);
    Task DeleteReviewAsync(int id);
}