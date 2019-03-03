using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public League League { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public DateTime MatchDay { get; set; }

        public int FTHomeGoals { get; set; }
        public int FTAwayGoals { get; set; }
        public int HTHomeGoals { get; set; }
        public int HTAwayGoals { get; set; }

        
        public MatchDetails MatchDetails { get; set; }


    }
}
