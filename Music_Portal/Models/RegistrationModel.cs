using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Поле является обязательным!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string? PasswordConfirm { get; set; }
    }
}
