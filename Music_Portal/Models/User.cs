using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Имя")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Логин")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Электронный адрес")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Уровень доступа")]
        public int? AccessLevel { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public User()
        {
            this.Songs = new HashSet<Song>();
        }

    }
}
