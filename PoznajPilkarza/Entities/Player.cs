﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Enitites
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int ShirtNumber { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public Nationality Nationality { get; set; }
        public Position Position { get; set; }
        public int Height { get; set; }

        public int Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
    }
}