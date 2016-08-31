using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using anntgc00492Shop.Service;

namespace anntgc00492Shop.Web.Models
{
    public class ProductTagViewModel
    {
        public int ProductId { set; get; }
        public int TagId { set; get; }
        public virtual ProductViewModel Products { set; get; }
        public virtual TagViewModel Tags { set; get; }
    }
}