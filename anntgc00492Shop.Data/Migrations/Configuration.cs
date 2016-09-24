using System.Collections.Generic;
using anntgc00492Shop.Common;
using anntgc00492Shop.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace anntgc00492Shop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<anntgc00492Shop.Data.Anntgc00492ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(anntgc00492Shop.Data.Anntgc00492ShopDbContext context)
        {
            //CreateUser(context);
            CreateProductCategorySample(context);
            CreateFooter(context);
        }

        private void CreateUser(Anntgc00492ShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new Anntgc00492ShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new Anntgc00492ShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "anntgc00492",
                Email = "anntgc00492@fpt.edu.vn",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Nguyen Trong An"

            };

            manager.Create(user, "gc00492");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("anntgc00492@fpt.edu.vn");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }


        private void CreateProductCategorySample(Anntgc00492ShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>
            {
                new ProductCategory() {Name = "Điện Lạnh",Alias = "dien-lanh",Status = true},
                new ProductCategory() {Name = "Viễn Thông",Alias = "vien-thong",Status = true},
                new ProductCategory() {Name = "Đồ gia dụng",Alias = "do-gia-dung",Status = true},
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }

        private void CreateFooter(Anntgc00492ShopDbContext context)
        {
            if (context.Footers.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
            {
                Footer defaultFooter = new Footer()
                {
                    Id = CommonConstants.DefaultFooterId,
                    Content = @"<div class='footer-bottom'>
                                    <div class='container'>
                                        <div class='footer-bottom-cate'>
                                            <h6>CATEGORIES</h6>
                                            <ul>
                                                <li><a href = '#' > Curabitur sapien</a></li>
                                                <li><a href = '#' > Dignissim purus</a></li>
                                            </ul>
                                        </div>
                                        <div class='footer-bottom-cate bottom-grid-cat'>
                                            <h6>FEATURE PROJECTS</h6>
                                            <ul>
                                                <li><a href = '#' > Curabitur sapien</a></li>
                                                <li><a href = '#' > Dignissim purus</a></li>

                                            </ul>
                                        </div>
                                        <div class='footer-bottom-cate'>
                                            <h6>TOP BRANDS</h6>
                                            <ul>
                                                <li><a href = '#' > Curabitur sapien</a></li>
                                                <li><a href = '#' > Dignissim purus</a></li>
                                            </ul>
                                        </div>
                                        <div class='footer-bottom-cate cate-bottom'>
                                            <h6>OUR ADDERSS</h6>
                                            <ul>
                                                <li>gravida at.</li>
                                                <li class='phone'>PH : 6985792466</li>
                                                <li class='temp'> <p class='footer-class'>Design by<a href= 'anntgc00492@fpt.edu.vn' target= '_blank' > W3layouts </ a > </ p ></ li >
                                            </ ul >
                                        </ div >
                                        < div class='clearfix'> </div>
                                    </div>
                                </div>"
                };
                context.Footers.Add(defaultFooter);
                context.SaveChanges();
            }
        }
    }
}


