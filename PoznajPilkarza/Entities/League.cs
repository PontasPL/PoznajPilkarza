using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Enitites
{
    public class League
    {
        public int LeagueId { get; set; }


        public string Name { get; set; }

        public Nationality Nationality { get; set; }
        public string SeasonYear { get; set; }

        public string WikiLink { get; set; }
        public string Description { get; set; }
    }
}
