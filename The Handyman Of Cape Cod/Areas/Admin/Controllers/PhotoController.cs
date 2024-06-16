using Microsoft.AspNetCore.Mvc;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Models.Photo;


namespace The_Handyman_Of_Cape_Cod.Areas.Admin.Controllers
{
    public class PhotoController : AdminBaseController
    {
        private readonly IPhotoService photoService;
        private readonly IProjectService projectService;

        public PhotoController(
            IPhotoService _photoService,
            IProjectService _projectService)
        {
            photoService = _photoService;
            projectService = _projectService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotos(int id)
        {
            if (!await projectService.ProjectExistsAsync(id))
            {
                return BadRequest();
            }

            var listOfFiles = Request.Form.Files.ToList();

            string[] supportedTypes = {"jpg", "jpeg", "png", "gif"};

            foreach (var file in listOfFiles)
            {
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("Error", "File Extension Is InValid - Only Upload JPG/JPEG/PNG/GIF File");
                    return BadRequest(ModelState);
                }
            }

            await photoService.UploadPhotosAsync(id, listOfFiles);

            ViewBag.Message = "Image(s) stored in database!";

            //return RedirectToAction(nameof(ProjectController.Details), nameof(ProjectController), new { id });
            return RedirectToAction("Details", "Project", new { id = id, Area = "Admin" });
        }
    }
}
