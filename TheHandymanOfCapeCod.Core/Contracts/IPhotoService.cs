using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHandymanOfCapeCod.Core.Contracts
{
    public interface IPhotoService
    {
        Task UploadPhotosAsync(int projectId, List<IFormFile> files);
    }
}
