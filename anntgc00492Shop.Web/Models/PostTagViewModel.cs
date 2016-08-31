using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace anntgc00492Shop.Web.Models
{
    public class PostTagViewModel
    {
        public int PostId { set; get; }
        public string TagId { set; get; }
        public virtual PostViewModel Post { set; get; }
        public virtual TagViewModel Tag { set; get; }
    }
}