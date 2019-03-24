using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;

namespace PoznajPilkarza.Models
{
    public class TeamDto
    {
        public string Name { get; set; }
        public int Formed { get; set; }
        public string WikiLink { get; set; }
        public string NameLeague { get; set; }

        public string NameStadium { get; set; }
        public int CapacityStadium { get; set; }

    }
}
