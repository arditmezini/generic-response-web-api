using System.Web.Mvc;

namespace GenericResponseAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fun API";

            return View();
        }
    }
}
