using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public League League { get; set; }

        public int Formed { get; set; }
        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }

        public Manager Manager { get; set; }
        public Stadium Stadium { get; set; }

    }
}
