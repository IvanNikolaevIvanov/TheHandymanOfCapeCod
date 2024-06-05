using Microsoft.AspNetCore.Mvc;
using TheHandymanOfCapeCod.Core.Contracts;

namespace The_Handyman_Of_Cape_Cod.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IProjectService projectService;

        public GalleryController(IProjectService _projectService)
        {
              projectService = _projectService;
        }

        public async Task<IActionResult> RecentProjects(string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var model = await projectService.AllProjectsAsync(sortOrder,
               currentFilter,
               searchString,
               pageNumber);

            return View(model);
        }
    }
}
