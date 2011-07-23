using System.Collections.Generic;
using System.Web.Mvc;
using TemplateAndData.Models;

namespace TemplateAndData.Controllers
{
    public class ProductServiceController : Controller
    {
        public ActionResult Products()
        {
            var template = "{{each(i, product) products}}<li>${product.Name} (${product.Height}mm x ${product.Width}mm)</li>{{/each}}";
            Response.AddHeader("X-View-Template", template);
            var model = new List<Product>();
            model.Add(new Product() { Name = "Monitor Audio PL-300", Height = 1113, Width = 410 });
            model.Add(new Product() { Name = "Monitor Audio RX-8", Height = 900, Width = 185 });
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
