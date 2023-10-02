using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        public string? Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        public string? Surname { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        public string? Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "PasswordsDontMatch")]
        public string? PasswordConfirm { get; set; }
    }
}
