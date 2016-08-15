using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Model.Models;
using Anntgc00492Shop.Data.Infrastructure;

namespace anntgc00492Shop.Data.Repositories
{
    public interface IProductRepository
    {
        
    }
    public class ProductRepository:RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
