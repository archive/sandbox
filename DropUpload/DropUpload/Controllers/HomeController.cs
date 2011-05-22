using System;
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

            return RedirectToAction("UploadDone");
        }

        public ActionResult UploadView(HttpPostedFileBase file)
        {
            return View();
        }

        public ActionResult UploadDone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadAjax(string qqfile)
        {
            //ContentType: "application/octet-stream"

            try
            {
                TextReader textReader = new StreamReader(Request.InputStream);
                var content = textReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, "application/json");
            }

            return Json(new { success = true }, "text/html");
        }
    }
}
