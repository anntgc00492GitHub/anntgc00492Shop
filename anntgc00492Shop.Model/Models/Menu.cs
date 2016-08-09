using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace anntgc00492Shop.Model.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public int MenuGroupId { set; get; }
        [ForeignKey("MenuGroupId")]
        public virtual MenuGroup MenuGroup { set; get; }


        [Required]
        [MaxLength(100)]
        public string Name { set; get; }

        [Required]
        [MaxLength(100)]
        public string Url { set; get; }
        [Required]
        [MaxLength(100)]
        public string Target { set; get; }
        public int? DisplayOrder { set; get; }

        public bool Status { set; get; }
    }
}