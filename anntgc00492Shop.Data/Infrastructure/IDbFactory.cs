using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anntgc00492Shop.Data.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
        Anntgc00492ShopDbContext Init();
    }
}
