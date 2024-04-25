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

        public int Game_PublisherId { get; set; }

        public int PlatformId { get; set; }

        [ForeignKey("Game_PublisherId")]
        public Game_Publisher Game_Publisher { get; set; }

        [ForeignKey("PlatformId")]
        public Platform Platform { get; set; }
    }
}
