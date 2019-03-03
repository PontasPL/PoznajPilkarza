using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class LeagueDto
    {
        public int LeagueId { get; set; }


        public string Name { get; set; }

        public NationalityDto Nationality { get; set; }
        public string SeasonYear { get; set; }

        public string WikiLink { get; set; }
        public string Description { get; set; }
    }
}
