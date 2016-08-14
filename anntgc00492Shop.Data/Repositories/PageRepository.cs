using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Model.Models;

namespace anntgc00492Shop.Data.Repositories
{
    public interface IPageRepository
    {
        
    }
    public class PageRepository:RepositoryBase<Page> ,IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
