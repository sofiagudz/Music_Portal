using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        public string? Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
