using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace AnimalsWeb.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal Animal { get; set; } = null!;

        [Display(Name = "Comment:")]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        [Required(ErrorMessage = "need Comment.")]
        public string Content { get; set; } = null!;

    }
}
