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
            productCategory.Name = "product category  name 1";
            productCategory.Alias = "product category alias 1";
            var result = productCategoryRespository.Add(productCategory);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.Id);
        }

        [TestMethod]
        public void ProductCategory_GetAll()
        {
            var productCategoryList = productCategoryRespository.GetAll().ToList();
            Assert.AreEqual(1,productCategoryList.Count);
        }
    }
}
