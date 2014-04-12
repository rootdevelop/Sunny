using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sunny.Services.Domain;
using Sunny.Services.Services;

namespace Sunny.Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendPush()
        {
            return View(new PushModel());
        }

        [HttpPost]
        public async Task<ActionResult> SendPush(PushModel pushModel)
        {
            await PushService.SendNotification(pushModel.Message);

            return RedirectToAction("Yeeeey");
        }
    }
}