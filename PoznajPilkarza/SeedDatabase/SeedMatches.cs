using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper;
using Diacritics.Extensions;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;
using PoznajPilkarza.Models;
using Match = PoznajPilkarza.Enitites.Match;

namespace PoznajPilkarza.SeedDatabase
{
    public static class SeedMatches
    {
        public static void EnsureSeedDataForContext(this MatchContext context)
        {

            if (context.Matches.Any())
            {
                return;
            }

            addEmptyReferee(context);
            //var league = "D1";
            var leagues = new List<string>
            {
                "D1",
                "E0",
                "F1",
                "D1",
                "SP1"
            };
            foreach (var league in leagues)
            {
                GetMatches(context, league);
            }
        }

        private static void GetMatches(MatchContext context, string league)
        {
            var fileList = getCSV($@"http://www.football-data.co.uk/mmz4281/1819/{league}.csv");
            var matchList = new List<Match>();
            League nameLeague = new League();
            switch (league)
            {
                case "I1":
                {
                    nameLeague = context.Leagues.FirstOrDefault(l => l.Nationality.Name == "Italy" && l.Name == "Serie A");
                    break;
                }
                case "E0":
                {
                    nameLeague =
                        context.Leagues.FirstOrDefault(
                            l => l.Nationality.Name == "United Kingdom" && l.Name == "Premier League");
                    break;
                }
                case "D1":
                {
                    nameLeague = context.Leagues.FirstOrDefault(l => l.Nationality.Name == "Germany" && l.Name == "Bundesliga");
                    break;
                }
                case "F1":
                {
                    nameLeague = context.Leagues.FirstOrDefault(l => l.Nationality.Name == "France" && l.Name == "Ligue 1");
                    break;
                }
                case "SP1":
                {
                    nameLeague = context.Leagues.FirstOrDefault(l => l.Nationality.Name == "Spain" && l.Name == "LaLiga");
                    break;
                }
            }

            var configCSV = new CsvHelper.Configuration.Configuration
            {
                Delimiter = ",",
                IgnoreBlankLines = true,
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var csv = new CsvReader(fileList, configCSV))
            {
                var matches = csv.GetRecords<MatchCSV>();
                foreach (var match in matches)
                {
                    matchList.Add(new Match
                    {
                        League = nameLeague,
                        HomeTeam = context.Teams.FirstOrDefault(ht =>
                            Regex.IsMatch(ht.Name.RemoveDiacritics().ToLower(), FixTeamName(match.HomeTeam).ToLower())),
                        AwayTeam = context.Teams.FirstOrDefault(ht =>
                            Regex.IsMatch(ht.Name.RemoveDiacritics().ToLower(), FixTeamName(match.AwayTeam).ToLower())),
                        FTHomeGoals = match.FTHG,
                        FTAwayGoals = match.FTAG,
                        HTHomeGoals = match.HTHG,
                        HTAwayGoals = match.HTAG,
                        MatchDay = DateTime.Parse(match.Date),
                        MatchDetails = GetMatchDetails(match, nameLeague.NationalityId, context,
                            context.Teams.FirstOrDefault(ht =>
                                    Regex.IsMatch(ht.Name.RemoveDiacritics().ToLower(), FixTeamName(match.HomeTeam).ToLower()))
                                .StadiumId)
                    });
                }
            }

            context.Matches.AddRange(matchList);
            context.SaveChanges();
        }

        private static string FixTeamName(string nameTeam)
        {
            nameTeam =nameTeam.Replace("Man City", "Manchester City");
            nameTeam = nameTeam.Replace("Man United", "Manchester United");
            nameTeam =nameTeam.Replace("Wolves", "Wolverhampton");
            nameTeam = nameTeam.Replace("Ath Bilbao", "Athletic Bilbao");
            nameTeam = nameTeam.Replace("Ath Madrid", "Atlético Madrid");
            nameTeam = nameTeam.Replace("Espanol", "Espanyol");
            nameTeam = nameTeam.Replace("Paris SG", "Paris Saint-Germain");
            nameTeam = nameTeam.Replace("St Etienne", "Saint-Etienne");
            nameTeam = nameTeam.Replace("Ein Frankfurt", "Eintracht Frankfurt");
            nameTeam = nameTeam.Replace("M'gladbach", "Borussia Mönchengladbach");
            nameTeam = nameTeam.Replace("Werder Brema", "Werder Bremen");
            return nameTeam.RemoveDiacritics();
        }
        private static void addEmptyReferee(MatchContext context)
        {
            var noDataReferee = new Referee
            {
                Name = "No data",
                Surname = "No data",
                Description = "No data",
                WikiLink = "No data",
                PngImage = "No data",
                Nationality = context.Nationalities.FirstOrDefault(n=>n.Name=="No data")
            };
            context.Referees.Add(noDataReferee);
            context.SaveChanges();
        }

        private static MatchDetails GetMatchDetails(MatchCSV match,int refereeCountry,MatchContext context,int homeTeam)
        {
         
            var matchDetails = new MatchDetails
            {
                HomeTeamCorners = match.HC,
                AwayTeamCorners = match.AC,
                HomeTeamFoulsCommitted = match.HF,
                AwayTeamFoulsCommitted = match.AF,
                HomeTeamShots = match.HS,
                AwayTeamShots = match.AS,
                HomeTeamShotsOnTarget = match.HST,
                AwayTeamShotsOnTarget = match.AST,
                HomeYellowCards = match.HY,
                AwayYellowCards = match.AY,
                HomeTeamRedCards = match.HR,
                AwayTeamRedCards = match.AR,
                HomeTeamOffsides = GetRandom(1,7),
                AwayTeamOffsides = GetRandom(1,7),
                AwayTeamWoodWork = GetRandom(0,4),
                HomeTeamWoodWork = GetRandom(0,4),
                Attendance = Convert.ToInt32(Math.Round((GetRandom(60,95)*0.01)*context.Stadium.FirstOrDefault(s=>s.StadiumId==homeTeam).Capacity,0)),
                RefereeId = match.Referee!=null ?  GetReferee(match.Referee,refereeCountry,context) : context.Referees.FirstOrDefault(r=>r.Name=="No data").RefereeId
            };
            context.MatchesDetails.Add(matchDetails);
            context.SaveChanges();
            return matchDetails;
        }

        private static int GetRandom(int minValue, int maxValue)
        {
            var random = new Random();
            var randomNumber= random.Next(minValue, maxValue);
            return randomNumber;
        }

        private static int GetReferee(string matchReferee, int refereeCountry,MatchContext context)
        {
           
            var nameReferee = matchReferee.Substring(0, 1);
            var surnameReferee = matchReferee.Substring(2, matchReferee.Length - 2);
            if (!context.Referees.Any(n => n.Name == nameReferee && n.Surname == surnameReferee))
            {
                var wikiReferee = SeedWikipedia.GetWiki(matchReferee + " referee").Result;
                var referee = new Referee
                {
                    Name = matchReferee.Substring(0, 1),
                    Surname = matchReferee.Substring(2, matchReferee.Length - 2),
                    PngImage = "No data",
                    Nationality = context.Nationalities.FirstOrDefault(n => n.NationalityId == refereeCountry),
                    Description = wikiReferee.Description,
                    WikiLink = wikiReferee.Link
                };


                context.Referees.Add(referee);
                context.SaveChanges();
            }

            var refereeId = context.Referees.FirstOrDefault(n => n.Name == nameReferee && n.Surname == surnameReferee)
                .RefereeId;

            return refereeId;
        }

        private static StreamReader getCSV(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var streamReader = new StreamReader(response.GetResponseStream());
            return streamReader;
        }

    }
}
