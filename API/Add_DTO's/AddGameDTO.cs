using System.ComponentModel.DataAnnotations;

namespace API.Add_DTO_s
{
    public class AddGameDTO
    {
        [StringLength(200)]
        public string Game_Name { get; set; }

        public int GenreId { get; set; }
    }
}
