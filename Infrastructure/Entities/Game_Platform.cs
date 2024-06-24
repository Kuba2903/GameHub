using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Game_Platform
    {
        public int Id { get; set; }

        public int ReleaseYear { get; set; }

        //foreign keys

        public int GameId { get; set; }

        public int PlatformId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [ForeignKey("PlatformId")]
        public Platform Platform { get; set; }


        public ICollection<Region_Sales> Region_Sales { get; set; }
    }
}
