﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.WebPages.Scope;
using anntgc00492Shop.Model.Models;
using anntgc00492Shop.Service;
using anntgc00492Shop.Web.Infrastructure.Core;
using anntgc00492Shop.Web.Infrastructure.Extensions;
using anntgc00492Shop.Web.Models;
using AutoMapper;

namespace anntgc00492Shop.Web.Api
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            _productService = productService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 2)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _productService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page*pageSize).Take(pageSize);
                var responseData=Mapper.Map<IEnumerable<Product>,IEnumerable<ProductViewModel>>(query);
                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    Page=page,
                    TotalCount=totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow/pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }


        [Route("getbyId/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetById(id);
                var responseData = Mapper.Map<Product, ProductViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]//không có cái này dùng bên angular gọi lỗi 
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newProduct=new Product();
                newProduct.UpdateProduct(productViewModel);
                newProduct.CreatedDate = DateTime.Now;
                _productService.Add(newProduct);
                _productService.Save();
                var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
                response = request.CreateResponse(HttpStatusCode.Created, responseData);
            }
            return response;
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var selectedProduct = _productService.GetById(productViewModel.Id);
                    selectedProduct.UpdateProduct(productViewModel);
                    selectedProduct.UpdatedDate = DateTime.Now;
                    _productService.Update(selectedProduct);
                    _productService.Save();
                    //Xử lý báo kết quả về
                    var responseData = Mapper.Map<Product, ProductViewModel>(selectedProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProductCategory = _productService.Delete(id);
                    _productService.Save();
                    var responseData = Mapper.Map<Product, ProductViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }


        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProducts)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid) //Thiếu dấu ! là báo lỗi trả vẻ bên js đọc là không thành công
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var listProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);
                foreach (var item in listProduct)
                {
                    _productService.Delete(item);
                }
                _productService.Save();
                response = request.CreateResponse(HttpStatusCode.OK, listProduct.Count);

            }
            return response;
        }
    }
}