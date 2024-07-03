using System.ComponentModel.DataAnnotations;

namespace NorthWind.Api.Models
{
    public class MyCategoryDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="CategoryName alani Zorunludur")]
        [MaxLength(50,ErrorMessage ="En fazla 50 karakter olabilir")]
        [MinLength(2,ErrorMessage ="En Az 2 karakter olmalidir")]
        public string CategoryName { get; set; }
        public string Source { get; set; }
    }
}
