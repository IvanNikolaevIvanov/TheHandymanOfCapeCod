using Microsoft.AspNetCore.Http;

namespace TheHandymanOfCapeCod.Core.Contracts
{
    public interface IPhotoService
    {
        Task UploadPhotosAsync(int projectId, List<IFormFile> files);
    }
}
