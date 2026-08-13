using System.Net.Http.Json;
using Microsoft.JSInterop;
using silvaspoon.Models.Auth;

namespace silvaspoon.Services;

public class AuthApiService : IAuthApiService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;

    private const string TokenKey = "silvaspoon_auth_token";

    public AuthApiService(
        HttpClient httpClient,
        IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/auth/login",
            request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content
            .ReadFromJsonAsync<LoginResponse>();

        if (result is null || string.IsNullOrWhiteSpace(result.Token))
        {
            return null;
        }

        await _jsRuntime.InvokeVoidAsync(
            "localStorage.setItem",
            TokenKey,
            result.Token);

        return result;
    }

    public async Task LogoutAsync()
    {
        await _jsRuntime.InvokeVoidAsync(
            "localStorage.removeItem",
            TokenKey);
    }

    public async Task<string?> GetTokenAsync()
    {
        return await _jsRuntime.InvokeAsync<string?>(
            "localStorage.getItem",
            TokenKey);
    }
}