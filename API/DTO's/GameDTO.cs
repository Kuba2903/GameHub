using System.ComponentModel.DataAnnotations;

namespace API.DTO_s
{
    public class GameDTO
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Game_Name { get; set; }

        public int GenreId { get; set; }
    }
}
