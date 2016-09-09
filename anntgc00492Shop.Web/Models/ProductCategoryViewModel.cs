using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using anntgc00492Shop.Model.Models;

namespace anntgc00492Shop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { set; get; }
        public int? ParentId { set; get; }
        [Required(ErrorMessage = "Yêu cầu nhập tên danh mục")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề seo")]
        public string Alias { set; get; }
        public string Image { set; get; }
        public string Description { set; get; }

        public int? DisplayOrder { set; get; }
        public int? HomeFlag { set; get; }

        public virtual IEnumerable<ProductViewModel> Products { set; get; }

        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public string UpdatedBy { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        [Required(ErrorMessage = "Yêu cầu nhập trạng thái")]
        public bool Status { set; get; }
    }
}