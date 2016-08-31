using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using anntgc00492Shop.Model.Models;
using anntgc00492Shop.Web.Models;

namespace anntgc00492Shop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.Id = postCategoryVm.Id;
            postCategory.ParentId = postCategoryVm.ParentId;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Image = postCategoryVm.Image;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;

            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;            
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.Status = postCategoryVm.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.Id = postViewModel.Id;
            post.PostCategoryId = postViewModel.PostCategoryId;

            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;

            post.Description = postViewModel.Description;
            post.Content = postViewModel.Content;
            post.Image = postViewModel.Image;

            post.HomeFlag = postViewModel.HomeFlag;
            post.HotFlag = postViewModel.HotFlag;
            post.ViewCount = postViewModel.ViewCount;

            post.CreatedDate = postViewModel.CreatedDate;
            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.UpdatedBy = postViewModel.UpdatedBy;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory,
            ProductCategoryViewModel productCategoryVm)
        {
            productCategory.Id = productCategoryVm.Id;
            productCategory.ParentId = productCategoryVm.ParentId;

            productCategory.Name = productCategoryVm.Name;
            productCategory.Alias = productCategoryVm.Alias;

            productCategory.Description = productCategoryVm.Description;
            productCategory.Image = productCategoryVm.Image;

            productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
            productCategory.HomeFlag = productCategoryVm.HomeFlag;

            productCategory.CreatedDate = productCategoryVm.CreateDate;
            productCategory.CreatedBy = productCategoryVm.CreatedBy;
            productCategory.UpdatedDate = productCategoryVm.UpdatedDate;
            productCategory.UpdatedBy = productCategoryVm.UpdatedBy;
            productCategory.MetaKeyword = productCategoryVm.MetaKeyword;
            productCategory.MetaDescription = productCategoryVm.MetaDescription;
            productCategory.Status = productCategoryVm.Status;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.Id = productViewModel.Id;
            product.CategoryId = productViewModel.CategoryId;

            product.Name = productViewModel.Name;
            product.Alias = productViewModel.Alias;

            product.Image = productViewModel.Image;
            product.MoreImages = productViewModel.MoreImages;

            product.Description = productViewModel.Description;
            product.Content = productViewModel.Content;

            product.OriginalPrice = productViewModel.OriginalPrice;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.Quantity = productViewModel.Quantity;

            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.ViewCount = productViewModel.ViewCount;

            product.Tags = productViewModel.Tags;


            product.CreatedDate = productViewModel.CreatedDate;
            product.CreatedBy = productViewModel.CreatedBy;
            product.UpdatedDate = productViewModel.UpdatedDate;
            product.UpdatedBy = productViewModel.UpdatedBy;
            product.MetaKeyword = productViewModel.MetaKeyword;
            product.MetaDescription = productViewModel.MetaDescription;
            product.Status = productViewModel.Status;

        }

          public static void UpdateOrder(this Order order, OrderViewModel orderVm)
        {
            order.CustomerName = orderVm.CustomerName;
            order.CustomerId = orderVm.CustomerId;
            order.CustomerAddress = orderVm.CustomerName;
            order.CustomerEmail = orderVm.CustomerName;
            order.CustomerMobile = orderVm.CustomerMobile;
            order.CustomerMessage = orderVm.CustomerName;
            order.PaymentMethod = orderVm.CustomerName;
            order.CreatedDate = DateTime.Now;
            order.CreatedBy = orderVm.CreatedBy;
            order.Status = orderVm.Status;
        }
    }
}