﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Region
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Region_Name { get; set; }
    }
}
