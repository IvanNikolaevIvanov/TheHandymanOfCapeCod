using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TheHandymanOfCapeCod.Core.Constants.AdministratorConstants;

namespace The_Handyman_Of_Cape_Cod.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
