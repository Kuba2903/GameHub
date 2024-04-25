using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Publisher_Name { get; set; }


        public ICollection<Game_Publisher> Games_Publishers { get; set; }
    }
}
