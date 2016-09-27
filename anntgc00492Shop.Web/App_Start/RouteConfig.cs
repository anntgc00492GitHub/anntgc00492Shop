using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.XPath;

namespace anntgc00492Shop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.MapRoute(
            //    name: "About",
            //    url: "gioi-thieu.html",
            //    defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
            //    namespaces: new string[] { "anntgc00492Shop.Web.Controllers" }
            //);

            //routes.MapRoute(
            //   name: "Login",
            //   url: "dang-nhap.html",
            //   defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
            //   namespaces: new string[] { "anntgc00492Shop.Web.Controllers" }
            //);


            //routes.MapRoute(
            //    name: "Products In A Category",
            //    url: "{alias}.pc-{id}.html",
            //    defaults: new { controller = "Product", action = "ProductsInACategory", id = UrlParameter.Optional },
            //    namespaces: new string[] { "anntgc00492Shop.Web.Controllers" }
            //);

            //routes.MapRoute(
            //    name: "ProductDetail",
            //    url: "{alias}.p-{productId}.html",
            //    defaults: new { controller = "Product", action = "Detail", productId = UrlParameter.Optional },
            //    namespaces: new string[] { "anntgc00492Shop.Web.Controllers" }
            //);

            routes.MapMvcAttributeRoutes();///Them cai nay moi viet duoc ten route truoc action, nho khong co dau cham, kết hợp đc cái dưới để nguyên
            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "anntgc00492Shop.Web.Controllers" }
            );
        }
    }
}
