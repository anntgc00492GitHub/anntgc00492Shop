using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Data.Repositories;
using anntgc00492Shop.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace anntgc00492Shop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }


        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = null;
            category=new PostCategory();
            category.Name = "Test category2";
            category.Alias = "Test-category2";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();
            int i = result.Id;
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Id);
        }

        [TestMethod]
        public void PostCategory_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(2,list.Count);
        }


    }
}
