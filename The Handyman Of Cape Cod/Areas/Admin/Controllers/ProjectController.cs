using Microsoft.AspNetCore.Mvc;

namespace The_Handyman_Of_Cape_Cod.Areas.Admin.Controllers
{
    public class ProjectController : AdminBaseController
    {
        //public async Task<IActionResult> AllProjects()
        //{
        //    var model = await projectService.AllCategoriesAsync();

        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult AddCategory()
        //{
        //    var model = new CategoryFormModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddCategory(CategoryFormModel model)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    await projectService.AddCategoryAsync(model);

        //    return RedirectToAction(nameof(AllCategories));
        //}

        //[HttpGet]
        //public async Task<IActionResult> EditCategory(int id)
        //{
        //    if (!await projectService.ExistsAsync(id))
        //    {
        //        return BadRequest();
        //    }

        //    var model = await projectService.GetCategoryFormByIdAsync(id);

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditCategory(int id, CategoryDetailsViewModel model)
        //{
        //    if (!await projectService.ExistsAsync(id))
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    await projectService.EditAsync(id, model);

        //    return RedirectToAction(nameof(AllCategories));
        //}

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
