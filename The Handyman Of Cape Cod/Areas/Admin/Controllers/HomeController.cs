using Microsoft.AspNetCore.Mvc;

namespace The_Handyman_Of_Cape_Cod.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
