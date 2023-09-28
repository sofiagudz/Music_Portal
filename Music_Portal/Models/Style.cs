using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class Style
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string? Name { get; set; }
    }
}
