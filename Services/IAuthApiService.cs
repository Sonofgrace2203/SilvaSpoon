using silvaspoon.Models.Auth;

namespace silvaspoon.Services;

public interface IAuthApiService
{
    Task<LoginResponse?> LoginAsync(LoginRequest request);

    Task LogoutAsync();

    Task<string?> GetTokenAsync();
}