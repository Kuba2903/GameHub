using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class GameVm
    {
        public int Id { get; set; }

        [Display(Name = "Game name")]
        [Required(ErrorMessage = "Game name cannot be empty")]
        public string Game_Name { get; set; }
        public string? Genre { get; set; }
        public string Publisher { get; set; }
        [Required(ErrorMessage = "Description cannot be empty!")]
        public string Description { get; set; }
        public List<PlatformsVm> Platforms { get; set; } = new List<PlatformsVm>();

    }
}
