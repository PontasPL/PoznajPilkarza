using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public LeagueDto League { get; set; }

        public int Formed { get; set; }
        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }

        public ManagerDto Manager { get; set; }
        public StadiumDto Stadium { get; set; }

    }
}
