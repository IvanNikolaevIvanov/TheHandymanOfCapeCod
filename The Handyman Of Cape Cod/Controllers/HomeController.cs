using MailKit;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using The_Handyman_Of_Cape_Cod.Models;
using TheHandymanOfCapeCod.Core.Models.Message;

namespace The_Handyman_Of_Cape_Cod.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TheHandymanOfCapeCod.Core.Contracts.IMailService mailService;

        public HomeController(
            ILogger<HomeController> logger,
            TheHandymanOfCapeCod.Core.Contracts.IMailService _mailService)
        {
            _logger = logger;
            mailService = _mailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexFormModel();
            return View(model);
        }

        //[HttpPost]
        //public IActionResult SendMessage(IndexFormModel model)
        //{
        //    return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
