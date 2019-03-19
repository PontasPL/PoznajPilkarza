using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class MatchDto
    {
        public string LeagueName { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }

        public string MatchDay { get; set; }

        public int FTHomeGoals { get; set; }
        public int FTAwayGoals { get; set; }
        public int HTHomeGoals { get; set; }
        public int HTAwayGoals { get; set; }


        public MatchDetailsDto MatchDetailsDto { get; set; }

    }
}
