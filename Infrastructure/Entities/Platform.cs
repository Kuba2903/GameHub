using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Platform
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Platform_Name { get; set; }


        public ICollection<Game_Platform> Game_Platforms { get; set; }
    }
}
