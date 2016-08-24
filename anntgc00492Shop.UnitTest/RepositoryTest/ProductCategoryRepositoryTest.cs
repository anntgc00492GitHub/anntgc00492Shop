using System;
using System.Linq;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Data.Repositories;
using anntgc00492Shop.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace anntgc00492Shop.UnitTest.RepositoryTest
{
    [TestClass]
    public class ProductCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IProductCategoryRepository productCategoryRespository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory=new DbFactory();
            productCategoryRespository=new ProductCategoryRepository(dbFactory);
            unitOfWork=new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void ProductCategory_Repository_Create()
        {
            ProductCategory productCategory=new ProductCategory();
            productCategory.Name = "This is test product name 2";
            productCategory.Alias = "This is test product Alias";
            var result = productCategoryRespository.Add(productCategory);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.Id);
        }

        [TestMethod]
        public void ProductCategory_GetAll()
        {
            var productCategoryList = productCategoryRespository.GetAll().ToList();
            Assert.AreEqual(2,productCategoryList.Count);
        }
    }
}
