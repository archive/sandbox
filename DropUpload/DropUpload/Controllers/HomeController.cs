using System.IO;
using System.Web;
using System.Web.Mvc;

namespace DropUpload.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                TextReader textReader = new StreamReader(file.InputStream);
                var content = textReader.ReadToEnd();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadAjax(string qqfile)
        {
            //ContentType: "application/octet-stream"

            var keys = Request.Form.AllKeys;

            TextReader textReader = new StreamReader(Request.InputStream);
            var content = textReader.ReadToEnd();

            return RedirectToAction("Index");
        }
    }
}
