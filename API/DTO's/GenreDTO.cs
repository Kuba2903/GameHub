using System.ComponentModel.DataAnnotations;

namespace API.DTO_s
{
    public class GenreDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Genre_Name { get; set; }
    }
}
