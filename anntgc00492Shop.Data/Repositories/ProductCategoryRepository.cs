using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Model.Models;

namespace anntgc00492Shop.Data.Repositories
{
    public interface IProductCategoryRespository
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRepository:RepositoryBase<ProductCategory>,IProductCategoryRespository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
         
        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
