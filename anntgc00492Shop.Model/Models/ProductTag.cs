﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace anntgc00492Shop.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { set; get; }
        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }
        [Key]
        [Column(Order = 2,TypeName = "varchar")]
        [MaxLength(50)]
        public string TagId { set; get; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}