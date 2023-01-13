using AnimalsWeb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AnimalsWeb.Attributes;

namespace AnimalsWeb.ViewModel
{
    public class AnimalViewModel
    {
        public int AnimalId { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter Name.")]
        public string? Name { get; set; }

        [Display(Name = "Age:")]
        [Required(ErrorMessage = "Please enter Age.")]
        [Range(0, 150)]
        public int? Age { get; set; }

        [Display(Name = "Picture Name:")]
       // [ImageValidationAttribute(new string[] { "png", "jpg", "jpeg", "webp", "raw", "svg" }, ErrorMessage = "This file not allowed")]
        [Required(ErrorMessage = "please add image")]
        public IFormFile? PictureName { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Required(ErrorMessage = "need description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "please choose category")]
        public int CategoryId { get; set; }

    }
}
