using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anntgc00492Shop.Data.Infrastructure
{
    public class DbFactory:Disposable,IDbFactory
    {
        private Anntgc00492ShopDbContext dbContext;

        public Anntgc00492ShopDbContext Init()
        {
            return dbContext ?? (dbContext = new Anntgc00492ShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
