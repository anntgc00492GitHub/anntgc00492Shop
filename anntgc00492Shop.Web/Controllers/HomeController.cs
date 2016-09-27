using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using anntgc00492Shop.Data.Repositories;
using anntgc00492Shop.Model.Models;
using anntgc00492Shop.Service;
using anntgc00492Shop.Web.Models;
using AutoMapper;

namespace anntgc00492Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productCategoryService;
        private ICommonService _commonService;
        private IProductService _productService;

        public HomeController(IProductCategoryService productCategoryService,ICommonService commonService,IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _commonService = commonService;
            _productService = productService;
        }

        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            var slideViewModel=Mapper.Map<IEnumerable<Slide>,IEnumerable<SlideViewModel>>(slideModel);

            var productLastestModel = _productService.GetLatest(3);
            var productLastestViewModel=Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productLastestModel);

            var productTopSaleModel = _productService.GetLatest(3);
            var productTopSaleViewModel=Mapper.Map<IEnumerable<Product>,IEnumerable<ProductViewModel>>(productTopSaleModel);

            var homeViewModel=new HomeViewModel();
            homeViewModel.Slides = slideViewModel;
            homeViewModel.LastestProducts = productLastestViewModel;
            homeViewModel.TopSaleProducts = productTopSaleViewModel;

            return View(homeViewModel);
        }

        [Route("gioithieu")]
        public ActionResult About()
        {
            ViewBag.Message = "Xin chao den voi website chung toi";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView("Header");
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}