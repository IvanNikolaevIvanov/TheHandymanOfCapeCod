﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Globalization;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Models.Project;
using TheHandymanOfCapeCod.Infrastructure.Constants;

namespace The_Handyman_Of_Cape_Cod.Areas.Admin.Controllers
{
    public class ProjectController : AdminBaseController
    {
        private readonly IProjectService projectService;
        private readonly IPhotoService photoService;

        public ProjectController(
            IProjectService _projectService,
            IPhotoService _photoService)
        {
            projectService = _projectService;
            photoService = _photoService;
        }

        [HttpGet]
        public async Task<IActionResult> AllProjects(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            // Order By Date Descending Default
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewData["NameSortParm"] = sortOrder == "Title" ? "title_desc" : "Title";

            // Order By Title Default
            //ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var queryResult = await projectService.AllProjectsAsync(
               sortOrder,
               currentFilter,
               searchString,
               pageNumber);

            return View(queryResult);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await projectService.ProjectExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await projectService.ProjectDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddProject()
        {
            var model = new AddProjectFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectFormModel model)
        {
            DateTime projectDate = DateTime.Now;

            if (!DateTime.TryParseExact(model.ProjectStartDate,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out projectDate))
            {
                ModelState.AddModelError(nameof(model.ProjectStartDate),
                    $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var listOfFiles = Request.Form.Files.ToList();
            int id = 0;

            await projectService.AddProjectAsync(model.Title, projectDate);

            id = await projectService.GetLastProjectIdAsync();

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            if (!await projectService.ProjectExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await projectService.GetProjectFormByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(int id, AddProjectFormModel model)
        {
            if (!await projectService.ProjectExistsAsync(id))
            {
                return BadRequest();
            }

            DateTime projectDate = DateTime.Now;

            if (!DateTime.TryParseExact(model.ProjectStartDate,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out projectDate))
            {
                ModelState.AddModelError(nameof(model.ProjectStartDate),
                    $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await projectService.EditAsync(id, model.Title, projectDate);

            return RedirectToAction(nameof(Details), new { id });
        }

        //[HttpGet]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    if (!await projectService.ExistsAsync(id))
        //    {
        //        return BadRequest();
        //    }

        //    var categoryToDelete = await projectService.GetCategoryFormByIdAsync(id);

        //    var model = new CategoryViewModel()
        //    {
        //        Id = id,
        //        Title = categoryToDelete.Title,
        //        Description = categoryToDelete.Description,
        //        ImgUrl = categoryToDelete.ImgUrl
        //    };

        //    return View(model);
        //}
    }
}
