using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anntgc00492Shop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { set; get; }
        [Required]
        [MaxLength(100)]
        public string CustomerAddress { set; get; }
        [Required]
        [MaxLength(100)]
        public string CustomerEmail { set; get; }
        [Required]
        [MaxLength(100)]
        public string CusotmerMobile { set; get; }
        [Required]
        [MaxLength(100)]
        public string CustomerMessage { set; get; }

        [Required]
        [MaxLength(100)]
        public string PaymentMethod { set; get; }
        [Required]
        [MaxLength(100)]
        public string PaymentStatus { set; get; }

        [Required]
        [MaxLength(100)]
        public DateTime CreatedDate { set; get; }
        [Required]
        [MaxLength(100)]
        public string CreatedBy { set; get; }

        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }
    }
}
