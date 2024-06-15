using Microsoft.AspNetCore.Http;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Infrastructure.Data.Common;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;

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
            var project = await repository.GetByIdAsync<Project>(projectId);

            if (project != null)
            {
                foreach (var file in files)
                {
                    Photo photo = new Photo();

                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    photo.ImageData = ms.ToArray();
                    photo.ProjectId = projectId;

                    ms.Close();
                    ms.Dispose();

                    project.Photos.Add(photo);

                }
            }

            await repository.SaveChangesAsync();
        }
    }
}
