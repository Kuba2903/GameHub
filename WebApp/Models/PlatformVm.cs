using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class PlatformVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty!")]
        public string Name { get; set; }
    }
}
