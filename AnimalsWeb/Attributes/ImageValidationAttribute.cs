using System.ComponentModel.DataAnnotations;

namespace AnimalsWeb.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ImageValidationAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public ImageValidationAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (_extensions.Contains(extension.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }


}



