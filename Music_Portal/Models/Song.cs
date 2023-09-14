using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Название")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Альбом")]
        public string? Album { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Год выпуска")]
        public int? ReleaseYear { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        public string? Video { get; set; }

		public virtual User Publisher { get; set; }

        public int StyleId { get; set; }
		[Display(Name = "Стиль")]
		public virtual Style Style { get; set; }

        public int SingerId { get; set; }
		[Display(Name = "Исполнитель")]
		public virtual Singer Singer { get; set; }

    }
}
