using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using anntgc00492Shop.Model.Models;
using anntgc00492Shop.Web.Models;
using AutoMapper;

namespace anntgc00492Shop.Web.Mappings
{
    public class AutoMapperConfigure
    {
        public static void Configure()
        {
            Mapper.CreateMap<Tag, TagViewModel>();

            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostTag, PostTagViewModel>();

            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();

            Mapper.CreateMap<Footer, FooterViewModel>();
        }
    }
}