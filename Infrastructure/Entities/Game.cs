using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Game
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Game_Name { get; set; }

        public int GenreId { get; set; }
        public int PublisherId { get; set; }

        public string Description { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public ICollection<Game_Platform> Platforms { get; set; }
    }
}
