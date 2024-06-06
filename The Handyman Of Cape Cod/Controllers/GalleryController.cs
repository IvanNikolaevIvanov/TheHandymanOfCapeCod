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

        public async Task<IActionResult> RecentProjects(
         int? pageNumber)
        {
            int numberOfProjects = 15;

            var model = await projectService.GetRecentProjectsAsync(numberOfProjects,
               pageNumber);

            return View(model);
        }
    }
}
