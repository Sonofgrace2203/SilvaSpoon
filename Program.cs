using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using silvaspoon;
using silvaspoon.Services;
using silvaspoon.Services.Settings;
using silvaspoon.Services.Upload;
using silvaspoon.Services.Recipe;
using Microsoft.AspNetCore.Components.Authorization;
using silvaspoon.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient
// {
//     BaseAddress = new Uri("http://localhost:5147/")
// });

var apiBaseUrl = builder.HostEnvironment.IsDevelopment()
    ? "http://localhost:5147/"
    : "https://silvaspoonapi-2.onrender.com/";

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl)
});

builder.Services.AddScoped<IMealApiService, MealApiService>();
builder.Services.AddScoped<IOrderApiService, OrderApiService>();
builder.Services.AddScoped<IReviewApiService, ReviewApiService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<BusinessSettingsState>();
builder.Services.AddScoped<IBusinessSettingsApiService, BusinessSettingsApiService>();
builder.Services.AddScoped<IContactSettingsApiService, ContactSettingsApiService>();
builder.Services.AddScoped<IDeliverySettingsApiService, DeliverySettingsApiService>();
builder.Services.AddScoped<IMealSettingsApiService, MealSettingsApiService>();
builder.Services.AddScoped<IWhatsAppSettingsApiService, WhatsAppSettingsApiService>();
builder.Services.AddScoped<ISocialMediaSettingsApiService, SocialMediaSettingsApiService>();
builder.Services.AddScoped<IUploadApiService, UploadApiService>();
builder.Services.AddScoped<IImageUrlService, ImageUrlService>();
builder.Services.AddScoped<IRecipeApiService, RecipeApiService>();
builder.Services.AddScoped<RecipeFavoriteStorageService>();
builder.Services.AddScoped<RecipeRatingStorageService>();
builder.Services.AddScoped<IAuthApiService, AuthApiService>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();

