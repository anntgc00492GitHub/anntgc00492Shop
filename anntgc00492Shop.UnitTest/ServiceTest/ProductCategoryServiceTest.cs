using System;
using System.Collections.Generic;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Data.Repositories;
using anntgc00492Shop.Model.Models;
using anntgc00492Shop.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace anntgc00492Shop.UnitTest.ServiceTest
{
    [TestClass]
    public class ProductCategoryServiceTest
    {
        private Mock<IProductCategoryRepository> _mockProductCategoryRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IProductCategoryService _productCategoryService;
        private List<ProductCategory> _productCategoryList;

        [TestInitialize]
        public void Initialize()
        {
            _mockProductCategoryRepository=new Mock<IProductCategoryRepository>();
            _mockUnitOfWork=new Mock<IUnitOfWork>();
            _productCategoryService=new ProductCategoryService(_mockProductCategoryRepository.Object,_mockUnitOfWork.Object);
            _productCategoryList = new List<ProductCategory>()
            {
                new ProductCategory() {Name = "Laptop",Alias = "laptop",Status = true},
                new ProductCategory() {Name = "Mobile",Alias = "mobile",Status = true},
                new ProductCategory() {Name = "Printer",Alias = "Printer",Status = true},
            };
        }



        [TestMethod]
        public void ProductCategoryService_GetAll()
        {
            _mockProductCategoryRepository.Setup(m => m.GetAll(null)).Returns(_productCategoryList);

            var result = _productCategoryService.GetAll() as List<ProductCategory>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3,result.Count);
        }
    }
}
