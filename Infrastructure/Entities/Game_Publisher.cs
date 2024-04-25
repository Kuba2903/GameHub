using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Game_Publisher
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public int PublisherId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }


        public ICollection<Game_Platform> Game_Platforms { get; set; }
    }
}
