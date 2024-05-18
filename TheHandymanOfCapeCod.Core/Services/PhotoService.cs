using Microsoft.AspNetCore.Http;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Infrastructure.Data.Common;

namespace TheHandymanOfCapeCod.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository repository;

        public PhotoService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task UploadPhotosAsync(int projectId, List<IFormFile> files)
        {
            
        }
    }
}
