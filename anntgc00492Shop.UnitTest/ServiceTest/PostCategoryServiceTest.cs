using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Data.Repositories;
using anntgc00492Shop.Model.Models;
using anntgc00492Shop.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace anntgc00492Shop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listPostCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository=new Mock<IPostCategoryRepository>();
            _mockUnitOfWork=new Mock<IUnitOfWork>();
            _categoryService=new PostCategoryService(_mockRepository.Object,_mockUnitOfWork.Object);
            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory() {Id = 1, Name = "DM1", Status = true},
                new PostCategory() {Id = 2, Name = "Dm2", Status = true},
                new PostCategory() {Id = 3, Name = "DM3", Status = true},
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //Set up method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listPostCategory);
            //Call action
            var result = _categoryService.GetAll() as List<PostCategory>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3,result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory postCategory=new PostCategory();
            postCategory.Name = "Test";
            postCategory.Alias = "Test";
            postCategory.Status = true;

            _mockRepository.Setup(m => m.Add(postCategory)).Returns((PostCategory p) => { p.Id = 1;return p;});
            var result = _categoryService.Add(postCategory);
            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.Id);
        }
    }
}
