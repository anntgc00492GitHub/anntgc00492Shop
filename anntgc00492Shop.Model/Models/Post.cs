using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using anntgc00492Shop.Model.Abstract;

namespace anntgc00492Shop.Model.Models
{
    [Table("Posts")]
    public class Post:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public int PostCategoryId { set; get; }
        [ForeignKey("PostCategoryId")]
        public virtual PostCategory PostCategory { set; get; }

        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Alias { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }
        [MaxLength(500)]
        public string Content { set; get; }
        [MaxLength(256)]
        public string Image { set; get; }

        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        public virtual IEnumerable<PostTag> PostTags { set; get; }
    }
}