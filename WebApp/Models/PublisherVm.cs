using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class PublisherVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Publisher name is required!")]
        public string Name { get; set; }
    }
}
