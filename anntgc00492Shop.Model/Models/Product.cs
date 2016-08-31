﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using anntgc00492Shop.Model.Abstract;

namespace anntgc00492Shop.Model.Models
{
    [Table("Products")]
    public class Product:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public int CategoryId { set; get; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }


        public string Image { set; get; }
        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }
        [MaxLength(500)]
        public string Content { set; get; }

        public decimal OriginalPrice { set; get; }
        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }
        public int Quantity { set; get; }

        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
        public string Tags { set; get; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}