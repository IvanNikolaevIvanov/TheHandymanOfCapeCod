using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using The_Handyman_Of_Cape_Cod.Models;
using TheHandymanOfCapeCod.Core.Models.Message;
using TheHandymanOfCapeCod.Core.Models.MailService;
using System.Text;
using TheHandymanOfCapeCod.Core.Constants;

namespace The_Handyman_Of_Cape_Cod.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService mailService;

        public HomeController(
            ILogger<HomeController> logger,
            IMailService _mailService)
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

        [HttpPost]
        public async Task<IActionResult> Index(IndexFormModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstants.EmailSendingFail] = "Message not sent! Please, try again!";
                return View(model);
            }

            MailData mailData = new MailData();
            mailData.EmailToId = "handymanofcapecod@gmail.com";
            mailData.EmailToName = "Krasimir Kirov";
            mailData.EmailSubject = "New client inquiry";

            var sb = new StringBuilder();

            sb.AppendLine($"This is a message send by a client using the Handyman Of Cape Cod Web Application.");
            sb.AppendLine($"From: {model.Name}");
            sb.AppendLine($"Phone number: {model.PhoneNumber}");
            sb.AppendLine($"Email: {model.Email}");
            sb.AppendLine($"Message: {model.Message}");

            mailData.EmailBody = sb.ToString().TrimEnd();

            await mailService.SendMailAsync(mailData);

            TempData[MessageConstants.EmailSendingSuccess] = "Your message has been sent successfully!";

            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
