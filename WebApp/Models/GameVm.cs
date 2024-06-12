﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class GameVm
    {
        public int Id { get; set; }

        public string Game_Name { get; set; }

        public string? Genre { get; set; }

        public string Publisher { get; set; }
        public string Description { get; set; }

        public List<PlatformsVm> Platforms { get; set; } = new List<PlatformsVm>();

    }
}
