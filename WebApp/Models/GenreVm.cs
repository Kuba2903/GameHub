using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class GenreVm
    {
        public int Id { get; set; }

        [Display(Name = "Genre name")]
        public string Genre_Name { get; set; }
    }
}
