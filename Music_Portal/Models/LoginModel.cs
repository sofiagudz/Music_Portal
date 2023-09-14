using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле является обязательным!")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
