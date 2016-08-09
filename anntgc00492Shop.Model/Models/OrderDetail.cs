using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace anntgc00492Shop.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { set; get; }
        [ForeignKey("OrderId")]
        public virtual Order Order { set; get; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { set; get; }
        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }

        public int Quantity { set; get; }
        public decimal Price { set; get; }
    }
}