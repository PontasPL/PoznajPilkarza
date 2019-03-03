using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class MatchDto
    {
        public int MatchId { get; set; }
        public LeagueDto League { get; set; }
        public TeamDto HomeTeam { get; set; }
        public TeamDto AwayTeam { get; set; }

        public DateTime MatchDay { get; set; }

        public int FTHomeGoals { get; set; }
        public int FTAwayGoals { get; set; }
        public int HTHomeGoals { get; set; }
        public int HTAwayGoals { get; set; }

        
        public MatchDetailsDto MatchDetails { get; set; }


    }
}
