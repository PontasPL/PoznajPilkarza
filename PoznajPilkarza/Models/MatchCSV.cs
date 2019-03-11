using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class MatchCSV
    {
        //League
        public string Div { get; set; }
        public  string Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        //Full Time Home Team Goals
        public int FTHG { get; set; }
        //Full Time Away Team Goals
        public int FTAG { get; set; }
        //Half Time Home Team Goals
        public int HTHG { get; set; }
        //Half Time Away Team Goals
        public int HTAG { get; set; }
        public int Attendance { get; set; }
        public string Referee { get; set; }
        //Home Team Shots
        public int HS { get; set; }
        //Away Team Shots
        public int AS { get; set; }
        //Home Team Shots on Target
        public int HST { get; set; }
        //Away Team Shots on Target
        public int AST { get; set; }
        //Home Team Corners
        public int HC { get; set; }
        //Away Team Corners
        public int AC { get; set; }
        //Home Team Fouls Committed
        public int HF { get; set; }
        //Away Team Fouls Committed
        public int AF { get; set; }
        //Home Team Yellow Cards
        public int HY { get; set; }
        //Away Team Yellow Cards
        public int AY { get; set; }
        //Home Team Red Cards
        public int HR { get; set; }
        //Away Team Red Cards
        public int AR { get; set; }
    }
}
