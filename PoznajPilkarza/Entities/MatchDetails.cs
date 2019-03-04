using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoznajPilkarza.Enitites
{
    public class MatchDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchDetailsId { get; set; }
        public int Attendance { get; set; }
        public int RefereeId { get; set; }
        public Referee Referee { get; set; }
        public int HomeTeamShots { get; set; }
        public int AwayTeamShots { get; set; }
        public int HomeTeamShotsOnTarget { get; set; }
        public int AwayTeamShotsOnTarget { get; set; }
        public int HomeTeamWoodWork { get; set; }
        public int AwayTeamWoodWork { get; set; }
        public int HomeTeamCorners { get; set; }
        public int AwayTeamCorners { get; set; }
        public int HomeTeamFoulsCommitted { get; set; }
        public int AwayTeamFoulsCommitted { get; set; }
        public int HomeTeamOffsides { get; set; }
        public int AwayTeamOffsides { get; set; }
        public int HomeYellowCards { get; set; }
        public int AwayYellowCards { get; set; }
        public int HomeTeamRedCards { get; set; }
        public int AwayTeamRedCards { get; set; }

        public virtual Match Match { get; set; }

    }
}