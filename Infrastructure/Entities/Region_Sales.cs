using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Region_Sales
    {
        //RegionId and Game_PlatformId is a composite key defined in onModelCreating method
        public int RegionId { get; set; }
        public int Game_PlatformId { get; set; }

        public int Num_Sales { get; set; }

        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        [ForeignKey("Game_PlatformId")]
        public Game_Platform Game_Platform { get; set; }
    }
}
