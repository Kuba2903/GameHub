using System.ComponentModel.DataAnnotations;

namespace API.Add_DTO_s
{
    public class AddGenreDTO
    {
        [StringLength(100)]
        public string Genre_Name { get; set; }
    }
}
