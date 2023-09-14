﻿using System.ComponentModel.DataAnnotations;

namespace Music_Portal.Models
{
    public class Style
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Название")]
        public string? Name { get; set; }
    }
}
