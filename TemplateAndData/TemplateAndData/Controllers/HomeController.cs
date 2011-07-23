using System.Web.Mvc;

namespace TemplateAndData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ViewProducts()
        {
            return View();
        }
    }
}
