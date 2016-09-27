using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace anntgc00492Shop.Web.Controllers
{
    [RoutePrefix("san-pham")]
    public class ProductController : Controller
    {
        [Route("trong-{alias}/{categoryId:int}")]
        public ActionResult ProductsInACategory(int categoryId)
        {
            return View();
        }
        [Route("chi-tiet-{alias}/{productId:int}")]
        public ActionResult Detail(int productId)
        {
            return View();
        }
    }
}