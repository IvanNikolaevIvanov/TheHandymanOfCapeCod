using Microsoft.AspNetCore.Mvc;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Models.Photo;

namespace The_Handyman_Of_Cape_Cod.Areas.Admin.Controllers
{
    public class PhotoController : AdminBaseController
    {
        private readonly IPhotoService photoService;

        public PhotoController(IPhotoService _photoService)
        {
             photoService = _photoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotos(int id)
        {

            var listOfFiles = Request.Form.Files.ToList();

            await photoService.UploadPhotosAsync(id, listOfFiles);

            return View();
        }
    }
}
