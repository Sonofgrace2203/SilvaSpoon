using Microsoft.AspNetCore.Components.Forms;

namespace silvaspoon.Services.Upload;

public interface IUploadApiService
{
    Task<string?> UploadImageAsync(
        IBrowserFile file,
        string folder);
}