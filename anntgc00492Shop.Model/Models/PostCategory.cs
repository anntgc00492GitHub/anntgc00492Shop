using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492Shop.Model.Abstract;

namespace anntgc00492Shop.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public int? ParentId { set; get; }

        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Alias { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }
        public string Image { set; get; }


        public int? DisplayOrder { set; get; }

        public virtual IEnumerable<Post> Posts { set; get; }
    }
}
