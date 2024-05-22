﻿using Microsoft.AspNetCore.Mvc;
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

            await photoService.UploadPhotosAsync(id, listOfFiles);

            ViewBag.Message = "Image(s) stored in database!";

            //return RedirectToAction(nameof(ProjectController.Details), nameof(ProjectController), new { id });
            return RedirectToAction("Details", "ProjectController", new { area = "Admin", id = id });
        }
    }
}
