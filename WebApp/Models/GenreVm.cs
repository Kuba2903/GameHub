using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class GenreVm
    {
        public int Id { get; set; }

        [Display(Name = "Genre name")]
        [Required(ErrorMessage = "Genre name cannot be empty!")]
        public string Genre_Name { get; set; }
    }
}
