using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string? Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Album", ResourceType = typeof(Resources.Resource))]
        public string? Album { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Year", ResourceType = typeof(Resources.Resource))]
        public int? ReleaseYear { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        public string? Video { get; set; }

		public virtual User Publisher { get; set; }

        public int StyleId { get; set; }
        [Display(Name = "Style", ResourceType = typeof(Resources.Resource))]
        public virtual Style Style { get; set; }

        public int SingerId { get; set; }
        [Display(Name = "Singer", ResourceType = typeof(Resources.Resource))]
        public virtual Singer Singer { get; set; }

    }
}
