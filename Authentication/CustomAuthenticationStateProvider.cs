using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace silvaspoon.Authentication;

public class CustomAuthenticationStateProvider
    : AuthenticationStateProvider
{
    private readonly Services.IAuthApiService _authApiService;

    private static readonly ClaimsPrincipal Anonymous =
        new(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(
        Services.IAuthApiService authApiService)
    {
        _authApiService = authApiService;
    }

    public override async Task<AuthenticationState>
        GetAuthenticationStateAsync()
    {
        var token = await _authApiService.GetTokenAsync();

        if (string.IsNullOrWhiteSpace(token))
        {
            return new AuthenticationState(Anonymous);
        }

        try
        {
            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token);

            if (jwtToken.ValidTo <= DateTime.UtcNow)
            {
                await _authApiService.LogoutAsync();

                return new AuthenticationState(Anonymous);
            }

            var identity = new ClaimsIdentity(
                jwtToken.Claims,
                authenticationType: "jwt");

            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        catch
        {
            await _authApiService.LogoutAsync();

            return new AuthenticationState(Anonymous);
        }
    }

    public void NotifyUserAuthentication(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        var jwtToken = handler.ReadJwtToken(token);

        var identity = new ClaimsIdentity(
            jwtToken.Claims,
            authenticationType: "jwt");

        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(user)));
    }

    public void NotifyUserLogout()
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(Anonymous)));
    }
}