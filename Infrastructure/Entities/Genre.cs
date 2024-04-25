using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Genre_Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
