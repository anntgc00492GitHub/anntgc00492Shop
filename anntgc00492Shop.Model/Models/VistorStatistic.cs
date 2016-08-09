using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anntgc00492Shop.Model.Models
{
    [Table("VistorStatistics")]
    public class VistorStatistic
    {
        [Key]
        public Guid Id { set; get; }
        [Required]
        public DateTime VisitedDate { set; get; }
        [MaxLength(50)]
        public string IpAddress { set; get; }
    }
}
