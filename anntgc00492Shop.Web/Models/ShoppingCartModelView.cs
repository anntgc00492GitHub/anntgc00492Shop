using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace anntgc00492Shop.Web.Models
{
    [Serializable]
    public class ShoppingCartModelView
    {
        public int ProductId { set; get; }
        public ProductViewModel Product { set; get; }
        public int Quantity { set; get; }
    }
}