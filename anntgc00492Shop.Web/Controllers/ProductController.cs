using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using anntgc00492Shop.Model.Models;
using anntgc00492Shop.Service;
using anntgc00492Shop.Web.Models;
using AutoMapper;
using PagedList;

namespace anntgc00492Shop.Web.Controllers
{
    [RoutePrefix("san-pham")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService,IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }


        //[Route("trong-{alias}/{categoryId:int}")]
        public ActionResult ProductsInACategory(int? categoryId,string searchString ,int? currentlySelectedCategoryIdParam, string currentSearchStringParam, string sortOrderParam, int? page)
        {
            if (!string.IsNullOrEmpty(categoryId.ToString()) && !string.IsNullOrEmpty(searchString))
            {
                page = 1;
            }
            else if(!string.IsNullOrEmpty(categoryId.ToString()))
            {
                page = 1;
                searchString = currentSearchStringParam;
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                page = 1;
                categoryId = currentlySelectedCategoryIdParam;
            }
            else
            {
                categoryId = currentlySelectedCategoryIdParam;
                searchString = currentSearchStringParam;
            }

          
            var productList = _productService.GetProductListByCategoryIdSearchSort(categoryId, searchString, sortOrderParam);
            var productViewModelList = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productList);


            ViewBag.CurrentSearchString = searchString;
            ViewBag.CurrentlySelectedCategoryId = categoryId;
            PoupulateCategory(categoryId);
            ViewBag.sortOrderParam = sortOrderParam;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrderParam) ? "Name" : "";
            ViewBag.PriceSortParm = string.IsNullOrEmpty(sortOrderParam) ? "Price" : "";

            return View(productViewModelList.ToPagedList(page ?? 1, 2));
        }

        private void PoupulateCategory(int? selectedCategoryId)
        {
            var productCategoryList = _productCategoryService.GetAll();
            var productCategoryViewModelList=Mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategory>>(productCategoryList);
            ViewBag.CurrentCategoryListWithSelectedItem = new SelectList(productCategoryViewModelList,"Id","Name", selectedCategoryId);
        }


        [Route("chi-tiet-{alias}/{productId:int}")]
        public ActionResult Detail(int productId)
        {
            return View();
        }
    }
}