using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Enitites
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }

        public int LeagueId { get; set; }
        public League League { get; set; }
        public int HomeTeamId { get; set; }
        
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        
        public Team AwayTeam { get; set; }

        public DateTime MatchDay { get; set; }

        public int FTHomeGoals { get; set; }
        public int FTAwayGoals { get; set; }
        public int HTHomeGoals { get; set; }
        public int HTAwayGoals { get; set; }

        public int MatchDetailsId { get; set; }
        
        public MatchDetails MatchDetails { get; set; }


    }
}
