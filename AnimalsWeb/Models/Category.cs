using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AnimalsWeb.Models
{
    public class Category
    {
        [Display(Name = "iD:")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Animal> Animals { get; set; } = new HashSet<Animal> { };
    }
}
