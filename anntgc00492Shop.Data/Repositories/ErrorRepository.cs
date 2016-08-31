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
    public interface IErrorRepository : IRepository<Error>
    {
        
    }
    public class ErrorRepository:RepositoryBase<Error>,IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
