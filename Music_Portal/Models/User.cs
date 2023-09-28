using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), 
            ErrorMessageResourceName = "Required")]
        [Display(Name = "NameU", ResourceType = typeof(Resources.Resource))]
        public string? Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Surname", ResourceType = typeof(Resources.Resource))]
        public string? Surname { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Lgn", ResourceType = typeof(Resources.Resource))]
        public string? Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "AccessLevel", ResourceType = typeof(Resources.Resource))]
        public int? AccessLevel { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public User()
        {
            this.Songs = new HashSet<Song>();
        }

    }
}
